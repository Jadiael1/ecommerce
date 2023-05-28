using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser;

// isso é a entrada do usuario
public class UpdateUserCommand : IRequest<Response<User>>
{
    [System.Text.Json.Serialization.JsonIgnore]
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Surname { get; set; } = string.Empty;
    public string? Login { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public string? Phone { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    public string? Photo { get; set; } = string.Empty;
    public bool? IsAdmin { get; set; }
    public bool? IsActive { get; set; }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<User>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepositoryAsync userRepositoryAsync, IMapper mapper)
        {
            _userRepositoryAsync = userRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<User>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepositoryAsync.UpdateUserByIdAsync(command);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }
            return new Response<User>(user, "Usuário editado com sucesso.");
        }
    }
}