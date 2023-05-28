using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<Response<User>>
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public IFormFile? Photo { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<User>>
{
    private readonly IUserRepositoryAsync _userRepositoryAsync;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepositoryAsync userRepositoryAsync, IMapper mapper)
    {
        _userRepositoryAsync = userRepositoryAsync;
        _mapper = mapper;
    }

    public async Task<Response<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (request.Password != request.ConfirmPassword)
        {
            throw new BadRequestException("Senhas não confere");
        }

        var user = _mapper.Map<User>(request);
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        if (request.Photo == null || request.Photo.Length == 0)
        {
            user.Photo = "uploads/users/default.png";
        }
        
        var isImageValid = await IsImageValid(request.Photo);
        if (request.Photo != null && !isImageValid)
        {
            throw new BadRequestException("Esta não é uma imagem valida");
        }

        if (request.Photo != null && request.Photo.Length > 0)
        {
            const int maxFileSize = 5 * 1024 * 1024;
            if (request.Photo.Length > maxFileSize)
            {
                throw new BadRequestException("O tamanho máximo do arquivo é de 5 MB.");
            }

            var fileName = Guid.NewGuid() + Path.GetExtension(request.Photo.FileName);
            var imagePath = Path.Combine("uploads/users", fileName);
            await using var imageStream = request.Photo.OpenReadStream();
            using var image = await Image.LoadAsync(imageStream, cancellationToken);
            await image.SaveAsync(imagePath, cancellationToken);
            user.Photo = imagePath;
        }
        try
        {
            var entityUser = await _userRepositoryAsync.AddAsync(user);
            entityUser.Password = "*************";
            return new Response<User>(entityUser, "Usuário criado com sucesso.");
        }
        catch (DbUpdateException ex) when (ex.InnerException is MySqlException { Number: 1062 })
        {
            throw new ConflictException("Já existe um usuário cadastrado com este mesmo e-mail");
        }
    }

    private static async Task<bool> IsImageValid(IFormFile file)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (file == null || !allowedExtensions.Contains(fileExtension))
        {
            return false;
        }

        try
        {
            using var image = await Image.LoadAsync(file.OpenReadStream());
            return image is { Width: > 0, Height: > 0 };
        }
        catch (Exception)
        {
            return false;
        }
    }
}