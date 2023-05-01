using Application.Features.Users.Queries.GetUsers;
using Application.Parameters;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IUserRepositoryAsync : IGenericRepositoryAsync<User>
{
    Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedUserResponseAsync(
        GetUsersQuery requestParameter);

    Task<User?> GetUserByIdAsync(int Id);
}