using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Parameters;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Users.Queries.GetUsers;

public class GetUsersQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
{
    public int Id { get; set; } = new int();
    public string Search { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PagedResponse<IEnumerable<Entity>>>
{
    private readonly IUserRepositoryAsync _userRepository;

    public GetUsersQueryHandler(IUserRepositoryAsync userRepositoryAsync)
    {
        _userRepository = userRepositoryAsync;
    }

    public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var entityUsers = await _userRepository.GetPagedUserResponseAsync(request);
        var data = entityUsers.data;
        RecordsCount recordCount = entityUsers.recordsCount;
        return new PagedResponse<IEnumerable<Entity>>(data, request.PageNumber, request.PageSize, recordCount);
    }
}

