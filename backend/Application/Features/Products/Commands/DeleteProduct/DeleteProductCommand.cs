using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<Response<Product>>
{
    public int Id { get; set; }
}

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<Product>>
{
    private readonly IProductRepositoryAsync _productRepositoryAsync;

    public DeleteProductCommandHandler(IProductRepositoryAsync productRepositoryAsync)
    {
        _productRepositoryAsync = productRepositoryAsync;
    }

    public async Task<Response<Product>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRepositoryAsync.DeleteProductByIdAsync(command);
        return new Response<Product>(product, "Produto Deletado Com Sucesso.");
    }
}