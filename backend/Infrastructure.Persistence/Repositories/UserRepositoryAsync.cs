using System.Linq.Dynamic.Core;
using Application.Features.Users.Queries.GetUsers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Parameters;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Extensions = LinqKit.Core.Extensions;

namespace Infrastructure.Persistence.Repositories;

public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
{
    private IDataShapeHelper<User> _dataShaper;
    private readonly DbSet<User> _users;

    public UserRepositoryAsync(ApplicationDbContext dbContext, IDataShapeHelper<User> dataShaper) : base(dbContext)
    {
        _dataShaper = dataShaper;
        _users = dbContext.Set<User>();
    }

    public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedUserResponseAsync(
        GetUsersQuery requestParameter)
    {
        var pageNumber = requestParameter.PageNumber;
        var orderBy = requestParameter.OrderBy;
        var fields = requestParameter.Fields;
        int recordsTotal, recordsFiltered;
        var result = _users.AsNoTracking().AsExpandable();
        recordsTotal = await result.CountAsync();
        FilterByColumn(ref result, requestParameter);
        recordsFiltered = await result.CountAsync();
        var pageSize = requestParameter.PageSize == 0 ? recordsFiltered : requestParameter.PageSize;
        var recordsCount = new RecordsCount
        {
            RecordsFiltered = recordsFiltered,
            RecordsTotal = recordsTotal
        };

        if (!string.IsNullOrWhiteSpace(orderBy))
        {
            result = result.OrderBy<User>(orderBy);
        }

        if (!string.IsNullOrWhiteSpace(fields))
        {
            result = result.Select<User>("new(" + fields + ")");
        }

        result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        var resultData = await result.ToListAsync();
        var shapeData = await _dataShaper.ShapeDataAsync(resultData, fields);
        return (shapeData, recordsCount);
    }

    private void FilterByColumn(ref IQueryable<User> users, GetUsersQuery requestParameter)
    {
        if (!users.Any())
            return;

        if (requestParameter is { Id: 0, IsActive: false, Search: null })
            return;

        var predicate = PredicateBuilder.New<User>();

        if (requestParameter.Id > 0)
            predicate = predicate.And(p => p.Id == requestParameter.Id);

        if (requestParameter.IsActive != false)
            predicate = predicate.And(p => p.IsActive == requestParameter.IsActive);

        if (!string.IsNullOrEmpty(requestParameter.Search))
            predicate = predicate.And(p =>
                p.Name.Contains(requestParameter.Search.ToUpper().Trim()) ||
                p.Surname.Contains(requestParameter.Search.ToUpper().Trim()));

        users = users.Where(predicate);
    }

    /*
    public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedUserResoibseAsync(GetUsersQuery requestParameter)
    {
        var pageNumber = requestParameter.PageNumber;
        var pageSize = requestParameter.PageSize;
        var orderBy = requestParameter.OrderBy;
        var fields = requestParameter.Fields;

        int recordsTotal, recordsFiltered;

        // Setup IQueryable
        var result = _users.AsNoTracking().AsExpandable();

        // Count records total
        recordsTotal = await result.CountAsync();

        // filter data
        FilterByColumn(ref result, requestParameter);

        // Count records after filter
        recordsFiltered = await result.CountAsync();

        //set Record counts
        var recordsCount = new RecordsCount
        {
            RecordsFiltered = recordsFiltered,
            RecordsTotal = recordsTotal
        };

        // set order by
        if (!string.IsNullOrWhiteSpace(orderBy))
        {
            result = result.OrderBy(orderBy);
        }

        // select columns
        if (!string.IsNullOrWhiteSpace(fields))
        {
            result = result.Select<User>("new(" + fields + ")");
        }
        // paging
        result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        // retrieve data to list
        var resultData = await result.ToListAsync();
        // shape data
        var shapeData = _dataShaper.ShapeData(resultData, fields);

        return (shapeData, recordsCount);

    }



    private void FilterByColumn(ref IQueryable<User> repositorios, GetUsersQuery requestParameter)
    {
        if (!repositorios.Any())
            return;

        if (requestParameter.Id == 0 &&
            requestParameter.Ativo == null &&
            string.IsNullOrEmpty(requestParameter.Search))
            return;

        var predicate = PredicateBuilder.New<User>();

        if (requestParameter.Id != 0)
            predicate = predicate.And(p => p.ID == requestParameter.Id);

        if (requestParameter.Ativo != null)
            predicate = predicate.And(p => p.ATIVO == requestParameter.Ativo);

        if (requestParameter.Tipo != null)
            predicate = predicate.And(p => requestParameter.Tipo.ToUpper().Trim().Contains(p.TIPO));

        if (!string.IsNullOrEmpty(requestParameter.Search))
            predicate = predicate.And(p => p.NOME.ToUpper().Trim().Contains(requestParameter.Pesquisa.ToUpper().Trim()) ||
                                           p.DESCRICAO.ToUpper().Trim().Contains(requestParameter.Pesquisa.ToUpper().Trim()));

        repositorios = repositorios.Where(predicate);
    }
    */
}