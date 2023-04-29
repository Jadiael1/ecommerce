using Application.Features.Users.Queries.GetUsers;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IUserRepositoryAsync : IGenericRepositoryAsync<User>
{
    Task<IEnumerable<User>> GetPagedUserResponseAsync(GetUsersQuery requestParameter);
}

