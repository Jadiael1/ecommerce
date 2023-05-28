using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetProductsById;

public class GetProductsByIdQuery : IRequest<Response<Product>>
{
    public int Id { get; set; }

    public class GetProductsByIdQueryHandler : IRequestHandler<GetProductsByIdQuery, Response<Product>>
    {
        private readonly IProductRepositoryAsync _productRepositoryAsync;

        public GetProductsByIdQueryHandler(IProductRepositoryAsync productRepositoryAsync)
        {
            _productRepositoryAsync = productRepositoryAsync;
        }

        public async Task<Response<Product>> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepositoryAsync.GetProductByIdAsync(request.Id);
            if (product == null)
            {
                throw new NotFoundException("Produto não localizado.");
            }
            return new Response<Product>(product);
        }
    }
}