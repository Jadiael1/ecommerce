using System.Linq.Dynamic.Core;
using Application.Exceptions;
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
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<User> _users;

    public UserRepositoryAsync(ApplicationDbContext dbContext, IDataShapeHelper<User> dataShaper) : base(dbContext)
    {
        _dataShaper = dataShaper;
        _users = dbContext.Set<User>();
        _dbContext = dbContext;
    }

    public async Task<User?> GetUserByIdAsync(int Id)
    {
        return await _users.Where(u => u.Id == Id).FirstOrDefaultAsync();
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
        if (resultData?.Count == 0)
        {
            throw new KeyNotFoundException("Nenhum user foi localizado.");
        }
        var shapeData = await _dataShaper.ShapeDataAsync(resultData, fields);
        return (shapeData, recordsCount);
    }

    public async Task<User> UpdateUserByIdAsync(User user)
    {
        _users.Update(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> DeleteUserByIdAsync(User user)
    {
        _users.Remove(user);
        await _dbContext.SaveChangesAsync();
        return user;
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
}