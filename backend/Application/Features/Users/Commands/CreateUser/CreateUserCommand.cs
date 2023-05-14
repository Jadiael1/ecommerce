using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<Response<User>>
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string ConfirmPassword { get; set; } = string.Empty;
    public string? Photo { get; set; } = string.Empty;
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
        var user = _mapper.Map<User>(request);
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        var entityUser = await _userRepositoryAsync.AddAsync(user);
        return new Response<User>(entityUser, "Usuario criado com sucesso.");
    }
}