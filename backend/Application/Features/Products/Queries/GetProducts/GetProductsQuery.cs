using Application.Interfaces.Repositories;
using Application.Parameters;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetProducts;

public class GetProductsQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
{
    public int Id { get; set; } = new int();
    public string Search { get; set; } = string.Empty;
}

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedResponse<IEnumerable<Entity>>>
{
    private readonly IProductRepositoryAsync _productRepository;

    public GetProductsQueryHandler(IProductRepositoryAsync productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var (data, recordCount) = await _productRepository.GetPagedProductsResponseAsync(request);
        return new PagedResponse<IEnumerable<Entity>>(data, request.PageNumber, request.PageSize, recordCount);
    }
}