using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<Response<Product>>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Amount { get; set; }
    public List<IFormFile> Photo { get; set; }
    public decimal Price { get; set; }
    public string TechnicalInformation { get; set; } = string.Empty;
    public int UserId { get; set; } = 0;
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<Product>>
{
    private readonly IProductRepositoryAsync _productRepositoryAsync;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductRepositoryAsync productRepositoryAsync, IMapper mapper)
    {
        _productRepositoryAsync = productRepositoryAsync;
        _mapper = mapper;
    }


    public async Task<Response<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepositoryAsync.CreateProductAsync(request);
        if (product == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }
        return new Response<Product>(product, "Produto criado com sucesso");
    }
}