using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

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
            throw new ApiException("Senhas não confere", 400);
        }

        var user = _mapper.Map<User>(request);
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        if (request.Photo == null || request.Photo.Length == 0)
        {
            user.Photo = "images\\default.png";
        }

        if (request.Photo != null && !IsImageValid(request.Photo))
        {
            throw new ApiException("Esta não é uma imagem valida", 500);
        }

        if (request.Photo != null && request.Photo.Length > 0)
        {
            var maxFileSize = 5 * 1024 * 1024;
            if (request.Photo.Length > maxFileSize)
            {
                throw new ApiException("O tamanho máximo do arquivo é de 5 MB.", 400);
            }
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Photo.FileName);
            string imagePath = Path.Combine("images", fileName);
            using Stream imageStream = request.Photo.OpenReadStream();
            using Image image = Image.Load(imageStream);
            image.Save(imagePath);
            user.Photo = imagePath;
        }


        var entityUser = await _userRepositoryAsync.AddAsync(user);
        entityUser.Password = "*************";
        return new Response<User>(entityUser, "Usuario criado com sucesso.");
    }

    private bool IsImageValid(IFormFile file)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (file == null || !allowedExtensions.Contains(fileExtension))
        {
            return false;
        }
        try
        {
            using var image = Image.Load(file.OpenReadStream());
            return image.Width > 0 && image.Height > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}