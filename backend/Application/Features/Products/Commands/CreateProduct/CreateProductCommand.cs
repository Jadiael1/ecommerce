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
        var product = _mapper.Map<Product>(request);
        if (request.Photo == null)
        {
            throw new ApiException("A imagem do produto é obrigatória.", 400);
        }

        List<string> photos = new List<string>();
        foreach (var file in request.Photo)
        {
            if (file.Length > 0 && IsImageValid(file))
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine("uploads\\products", fileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream, cancellationToken);
                photos.Add(filePath);
            }
        }
        product.Photo = JsonSerializer.Serialize(photos);

        var entityProduct = await _productRepositoryAsync.AddAsync(product);
        return new Response<Product>(entityProduct, "Produto criado com sucesso.");
    }

    private static bool IsImageValid(IFormFile file)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (file == null || !allowedExtensions.Contains(fileExtension))
        {
            return false;
        }
        try
        {
            using var image = Image.Load(file.OpenReadStream());
            return image.Width > 0 && image.Height > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
