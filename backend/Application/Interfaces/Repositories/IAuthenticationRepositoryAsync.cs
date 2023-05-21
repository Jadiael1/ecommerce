using Application.Features.Authentication.Commands;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IAuthenticationRepositoryAsync : IGenericRepositoryAsync<User>
{
    
}