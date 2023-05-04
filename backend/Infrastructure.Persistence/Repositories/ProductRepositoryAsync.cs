using System.Linq.Dynamic.Core;
using Application.Features.Products.Queries.GetProducts;
using Application.Features.Users.Queries.GetUsers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Parameters;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
{
    private IDataShapeHelper<Product> _dataShaper;
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<Product> _products;

    public ProductRepositoryAsync(ApplicationDbContext dbContext, IDataShapeHelper<Product> dataShaper) :
        base(dbContext)
    {
        _dataShaper = dataShaper;
        _products = dbContext.Set<Product>();
        _dbContext = dbContext;
    }

    public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedProductsResponseAsync(
        GetProductsQuery requestParameter)
    {
        var pageNumber = requestParameter.PageNumber;
        var orderBy = requestParameter.OrderBy;
        var fields = requestParameter.Fields;
        int recordsTotal, recordsFiltered;
        var result = _products.AsNoTracking().AsExpandable();
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
            result = result.OrderBy<Product>(orderBy);
        }

        if (!string.IsNullOrWhiteSpace(fields))
        {
            result = result.Select<Product>("new(" + fields + ")");
        }

        result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        var resultData = await result.ToListAsync();
        if (resultData?.Count == 0)
        {
            throw new KeyNotFoundException("Nenhum produto foi localizado.");
        }

        var shapeData = await _dataShaper.ShapeDataAsync(resultData, fields);
        return (shapeData, recordsCount);
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _products.Include(p => p.UserId).FirstOrDefaultAsync(p => p.Id == id);
    }

    private void FilterByColumn(ref IQueryable<Product> products, GetProductsQuery requestParameter)
    {
        if (!products.Any())
            return;

        if (requestParameter is { Id: 0, Search: null })
            return;

        var predicate = PredicateBuilder.New<Product>();

        if (requestParameter.Id > 0)
            predicate = predicate.And(p => p.Id == requestParameter.Id);

        if (!string.IsNullOrEmpty(requestParameter.Search))
            predicate = predicate.And(p =>
                p.Name.Contains(requestParameter.Search.ToUpper().Trim()));

        products = products.Where(predicate);
    }
}