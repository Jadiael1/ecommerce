using Application.Features.Products.Queries.GetProducts;
using Application.Parameters;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
{
    Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedProductsResponseAsync(
        GetProductsQuery requestParameter);

    Task<Product?> GetProductByIdAsync(int id);
}