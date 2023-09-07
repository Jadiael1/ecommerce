using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Application.Interfaces.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;


namespace Application.Features.Products.Commands.PatchProductImageCommand;

public class PatchProductImageCommand : IRequest<Response<Product>>
{
    public int ProductId { get; set; }
    public int PhotoId { get; set; }
    public IFormFile Photo { get; set; }
}

public class PatchProductImageCommandHandler : IRequestHandler<PatchProductImageCommand, Response<Product>>
{
    private readonly IProductRepositoryAsync _productRepositoryAsync;
    private readonly IMapper _mapper;

    public PatchProductImageCommandHandler(IProductRepositoryAsync productRepositoryAsync, IMapper mapper)
    {
        _productRepositoryAsync = productRepositoryAsync;
        _mapper = mapper;
    }

    public async Task<Response<Product>> Handle(PatchProductImageCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepositoryAsync.PatchProductImageByIdAsync(request);
        await Task.Delay(100, cancellationToken);
        return new Response<Product>(product, "Produto atualizado com sucesso.");
    }

    
    
}