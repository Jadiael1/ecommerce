using Application.Exceptions;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.PatchProduct;

public class PatchProductCommand : IRequest<Response<Product>>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public string TechnicalInformation { get; set; } = string.Empty;
}

public class PatchProductCommandHandler : IRequestHandler<PatchProductCommand, Response<Product>>
{
    private readonly IProductRepositoryAsync _productRepositoryAsync;

    private readonly IMapper _mapper;

    // private readonly IHttpContextAccessor _httpContextAccessor;
    // IHttpContextAccessor httpContextAccessor
    public PatchProductCommandHandler(IProductRepositoryAsync productRepositoryAsync, IMapper mapper)
    {
        _productRepositoryAsync = productRepositoryAsync;
        _mapper = mapper;
        // _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Response<Product>> Handle(PatchProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRepositoryAsync.PatchProductByIdAsync(command);
        if (product == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }
        return new Response<Product>(product, "Produto editado com sucesso.");
    }
}