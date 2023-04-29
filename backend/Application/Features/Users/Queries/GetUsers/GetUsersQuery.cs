// using Application.Interfaces.Repositories;
using Application.Parameters;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetUsers;

public class GetUsersQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<User>>>
{
    public long Id { get; set; }
    public string Search { get; set; } = String.Empty;
    public string type { get; set; } = String.Empty;
}

public class GetAllAgrupamentoColunasQueryHandler : IRequestHandler<GetUsersQuery, PagedResponse<IEnumerable<User>>>
{
    /*
    private readonly IUserRepositoryAsync _userRepository;

    public GetAllAgrupamentoColunasQueryHandler(IUserRepositoryAsync userRepositoryAsync)
    {
        _userRepository = userRepositoryAsync;
    }
    */


    public async Task<PagedResponse<IEnumerable<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        // var asd = _userRepository.GetPagedUserResoibseAsync(request);
        // var entityAgrupamentoColunas = await _agrupamentoColunaRepository.GetAgrupamentoColunasAsync(request.IdRepositorio, request.IdRepAgrupamento);

        List<User> users = new List<User>();
        users.Add(new User { Id = 1, Email = "email1@email.com", Login = "login1", Name = "name1", Created_at = new DateTime(), Password = "password1", Surname = "surname1" });
        users.Add(new User { Id = 2, Email = "email2@email.com", Login = "login2", Name = "name2", Created_at = new DateTime(), Password = "password2", Surname = "surname2" });

        // response wrapper
        return new PagedResponse<IEnumerable<User>>(users.AsEnumerable(), 5, 1, new RecordsCount());
    }
}

