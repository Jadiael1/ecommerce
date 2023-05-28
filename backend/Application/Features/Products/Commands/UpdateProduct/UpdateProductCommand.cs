using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Text.Json.Serialization;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using AutoMapper;

namespace Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<Response<Product>>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public int? Amount { get; set; }
    public decimal? Price { get; set; }
    public string? TechnicalInformation { get; set; } = string.Empty;
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<Product>>
{
    private readonly IProductRepositoryAsync _productRepositoryAsync;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductRepositoryAsync productRepositoryAsync, IMapper mapper)
    {
        _productRepositoryAsync = productRepositoryAsync;
        _mapper = mapper;
    }

    public async Task<Response<Product>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRepositoryAsync.UpdateProductByIdAsync(command);
        if (product == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }
        return new Response<Product>(product, "Produto editado com sucesso.");
    }
}