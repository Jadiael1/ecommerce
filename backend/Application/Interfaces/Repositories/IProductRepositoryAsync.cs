using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.PatchProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Queries.GetProducts;
using Application.Parameters;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
{
    Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedProductsResponseAsync(
        GetProductsQuery requestParameter);

    Task<Product?> GetProductByIdAsync(int id);

    Task<Product?> UpdateProductByIdAsync(UpdateProductCommand updateUserCommand);

    Task<Product?> DeleteProductByIdAsync(DeleteProductCommand request);

    Task<Product?> PatchProductByIdAsync(PatchProductCommand request);
}