using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<Response<User>>
{
    public int Id { get; set; }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<User>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public GetUserByIdQueryHandler(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<Response<User>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepositoryAsync.GetUserByIdAsync(query.Id);
            if (user == null)
            {
                throw new KeyNotFoundException("User não localizado.");
            }
            return new Response<User>(user);
        }
    }
}