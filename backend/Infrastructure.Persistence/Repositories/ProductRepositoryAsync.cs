using Application.Features.Products.Queries.GetProducts;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Parameters;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Application.DTOs.Product;
using Application.Exceptions;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.PatchProduct;
using Application.Features.Products.Commands.UpdateProduct;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

namespace Infrastructure.Persistence.Repositories;

public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
{
    private IDataShapeHelper<Product> _dataShaper;
    private readonly DbSet<Product> _products;
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProductRepositoryAsync(ApplicationDbContext dbContext, IDataShapeHelper<Product> dataShaper, IMapper mapper,
        IHttpContextAccessor httpContextAccessor) :
        base(dbContext)
    {
        _dataShaper = dataShaper;
        _products = dbContext.Set<Product>();
        _dbContext = dbContext;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Product?> DeleteProductByIdAsync(DeleteProductCommand request)
    {
        var product = await _products.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (product == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }

        _products.Remove(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateProductByIdAsync(UpdateProductCommand request)
    {
        var product = await _products.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (product == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }
        product = _mapper.Map(request, product);
        _dbContext.Entry(product).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> PatchProductByIdAsync(PatchProductCommand request)
    {
        var product = await _products.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (product == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }
        
        if (request.Name.Any())
            product.Name = request.Name;
            
        if (request.Description.Any())
            product.Description = request.Description;
            
        if (request.Amount > 0)
            product.Amount = request.Amount;
            
        if (request.Price > 0)
            product.Price = request.Price;
            
        if (request.TechnicalInformation.Any())
            product.TechnicalInformation = request.TechnicalInformation;
        
        _dbContext.Entry(product).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return product;
    }

    public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedProductsResponseAsync(
        GetProductsQuery requestParameter)
    {
        var pageNumber = requestParameter.PageNumber;
        var orderBy = requestParameter.OrderBy;
        var fields = requestParameter.Fields;
        var result = _products.AsNoTracking().AsExpandable();
        var recordsTotal = await result.CountAsync();
        FilterByColumn(ref result, requestParameter);
        var recordsFiltered = await result.CountAsync();
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

        result = result.Include(p => p.User);

        if (!string.IsNullOrWhiteSpace(fields))
        {
            result = result.Select<Product>("new(" + fields + ")");
        }

        result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        var resultData = await result.ToListAsync();
        if (resultData?.Count == 0)
        {
            throw new NotFoundException("Nenhum produto foi localizado.");
        }

        var shapeData = await _dataShaper.ShapeDataAsync(resultData, fields);
        return (shapeData, recordsCount);
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _products.FirstOrDefaultAsync(p => p.Id == id);
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

        if (requestParameter is { Id: 0, Search: "", OrderBy: "", Fields: "" })
        {
            predicate.And(x => true);
        }

        if (requestParameter is not { Fields: "" })
        {
            predicate.And(x => true);
        }

        products = products.Where(predicate);
    }
}