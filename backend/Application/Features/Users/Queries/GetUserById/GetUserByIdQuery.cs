using Application.DTOs.User;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<Response<ResponseUserDto>>
{
    public int Id { get; set; }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<ResponseUserDto>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public GetUserByIdQueryHandler(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<Response<ResponseUserDto>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepositoryAsync.GetUserByIdAsync(query.Id);
            if (user == null)
            {
                throw new NotFoundException("Usuário não localizado.");
            }
            return new Response<ResponseUserDto>(user);
        }
    }
}