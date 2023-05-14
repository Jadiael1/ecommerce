using Application.DTOs.User;
using Application.Features.Users.Commands.DeleteUser;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Queries.GetUserById;
using Application.Features.Users.Queries.GetUsers;
using Application.Parameters;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IUserRepositoryAsync : IGenericRepositoryAsync<User>
{
    Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedUserResponseAsync(
        GetUsersQuery requestParameter);

    Task<ResponseUserDto?> GetUserByIdAsync(int Id);

    Task<User> UpdateUserByIdAsync(UpdateUserCommand request);

    Task<User> DeleteUserByIdAsync(DeleteUserCommand request);
}