using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Response<User>>
{
    public int Id { get; set; }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<User>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public DeleteUserCommandHandler(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<Response<User>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            /*
            var user = await _userRepositoryAsync.GetUserByIdAsync(command.Id);
            if (user == null)
            {
                throw new KeyNotFoundException("User não localizado.");
            }
            */
            var user = await _userRepositoryAsync.DeleteUserByIdAsync(command);
            return new Response<User>(user, "Usuario Deletado Com Sucesso.");
        }
    }
}