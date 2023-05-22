using Application.DTOs.User;
using Application.Features.Users.Commands.DeleteUser;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Queries.GetUsers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Parameters;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Infrastructure.Persistence.Repositories;

public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
{
    private IDataShapeHelper<User> _dataShaper;
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<User> _users;
    private readonly IMapper _mapper;

    public UserRepositoryAsync(ApplicationDbContext dbContext, IDataShapeHelper<User> dataShaper, IMapper mapper) :
        base(dbContext)
    {
        _dataShaper = dataShaper;
        _users = dbContext.Set<User>();
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ResponseUserDto?> GetUserByIdAsync(int id)
    {
        return await _users.Include(u => u.Products).Select(u => new ResponseUserDto
        {
            Id = u.Id,
            Name = u.Name,
            Surname = u.Surname,
            Login = u.Login,
            Email = u.Email,
            Phone = u.Phone,
            Password = u.Password,
            BirthDate = u.BirthDate,
            Photo = u.Photo,
            IsAdmin = u.IsAdmin,
            IsActive = u.IsActive,
            Products = u.Products,
            CreatedAt = u.CreatedAt,
            UpdatedAt = u.UpdatedAt
        }).FirstOrDefaultAsync(u => u.Id == id);
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

        result = result.Include(u => u.Products);

        if (!string.IsNullOrWhiteSpace(fields))
        {
            result = result.Select<User>("new(" + fields + ")");
        }

        result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        var resultData = await result.Select(u => new User
        {
            Id = u.Id,
            Name = u.Name,
            Surname = u.Surname,
            Login = u.Login,
            Email = u.Email,
            Phone = u.Phone,
            Password = u.Password,
            BirthDate = u.BirthDate,
            Photo = u.Photo,
            IsAdmin = u.IsAdmin,
            IsActive = u.IsActive,
            Products = u.Products,
            CreatedAt = u.CreatedAt,
            UpdatedAt = u.UpdatedAt
        }).ToListAsync();

        if (resultData?.Count == 0 || resultData == null)
        {
            throw new KeyNotFoundException("Nenhum user foi localizado.");
        }

        var shapeData = await _dataShaper.ShapeDataAsync(resultData, fields);

        return (shapeData, recordsCount);
    }

    public async Task<User> UpdateUserByIdAsync(UpdateUserCommand request)
    {
        var user = await _users.FirstOrDefaultAsync(u => u.Id == request.Id);
        if (user == null)
        {
            throw new KeyNotFoundException("User não encontrado");
        }

        user = _mapper.Map(request, user);
        _users.Update(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> DeleteUserByIdAsync(DeleteUserCommand request)
    {
        var user = await _users.FirstOrDefaultAsync(u => u.Id == request.Id);
        if (user == null)
        {
            throw new KeyNotFoundException("User não encontrado");
        }

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

        if (requestParameter is { Id: 0, Search: "", IsActive: false, OrderBy: "", Fields: "" })
        {
            predicate.And(x => true);
        }

        if (requestParameter is not { Fields: "" })
        {
            predicate.And(x => true);
        }

        users = users.Where(predicate);
    }
}