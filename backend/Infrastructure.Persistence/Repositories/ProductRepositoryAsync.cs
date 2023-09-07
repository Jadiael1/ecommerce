using Application.Features.Products.Queries.GetProducts;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Parameters;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Application.DTOs.Product;
using Application.Exceptions;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.PatchProduct;
using Application.Features.Products.Commands.PatchProductImageCommand;
using Application.Features.Products.Commands.UpdateProduct;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using MySqlConnector;
using SixLabors.ImageSharp;

namespace Infrastructure.Persistence.Repositories;

public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
{
    private readonly IDataShapeHelper<Product> _dataShaper;
    private readonly DbSet<Product> _products;
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProductRepositoryAsync(ApplicationDbContext dbContext, IDataShapeHelper<Product> dataShaper, IMapper mapper,
        IHttpContextAccessor httpContextAccessor) :
        base(dbContext)
    {
        _dataShaper = dataShaper;
        _products = dbContext.Set<Product>();
        _dbContext = dbContext;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }
    
    
    public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedProductsResponseAsync(
        GetProductsQuery requestParameter)
    {
        var pageNumber = requestParameter.PageNumber;
        var orderBy = requestParameter.OrderBy;
        var fields = requestParameter.Fields;
        var result = _products.AsNoTracking().AsExpandable();
        var recordsTotal = await result.CountAsync();
        FilterByColumn(ref result, requestParameter);
        var recordsFiltered = await result.CountAsync();
        var pageSize = requestParameter.PageSize == 0 ? recordsFiltered : requestParameter.PageSize;
        var recordsCount = new RecordsCount
        {
            RecordsFiltered = recordsFiltered,
            RecordsTotal = recordsTotal
        };

        if (!string.IsNullOrWhiteSpace(orderBy))
        {
            result = result.OrderBy<Product>(orderBy);
        }

        result = result.Include(p => p.User).Include(p => p.Photos);

        if (!string.IsNullOrWhiteSpace(fields))
        {
            result = result.Select<Product>("new(" + fields + ")");
        }

        result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        var resultData = await result.ToListAsync();
        if (resultData?.Count == 0)
        {
            throw new NotFoundException("Nenhum produto foi localizado.");
        }

        var shapeData = await _dataShaper.ShapeDataAsync(resultData, fields);
        return (shapeData, recordsCount);
    }
    
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _products.Include(p => p.User).Include(p => p.Photos).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> CreateProductAsync(CreateProductCommand request)
    {
        var product = _mapper.Map<Product>(request);
        if (request.Photo == null)
        {
            throw new BadRequestException("A imagem do produto é obrigatória.");
        }
        var photos = new List<dynamic>();
        foreach (var file in request.Photo)
        {
            var isImageValid = await IsImageValid(file);
            if (file.Length <= 0 || !isImageValid) continue;
            var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine("uploads/products", newFileName);
            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            photos.Add(new {fileName = file.FileName, newFileName = newFileName, filePath = filePath });
        }
        if (!photos.Any())
        {
            throw new BadRequestException("Nenhuma das suas imagens são validas, Você precisa enviar pelo menos 1 imagem valida para cadastrar seu produto.");
        }
        await _products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        
        photos.ForEach(async photo =>
        {
            var productPhoto = new ProductPhoto
            {
                ProductId = product.Id,
                Name = photo.fileName.ToString(),
                NewName = photo.newFileName.ToString(),
                Path = photo.filePath.ToString(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _dbContext.ProductPhoto.AddAsync(productPhoto);
        });
        await _dbContext.SaveChangesAsync();
        return product;
    }
    
    public async Task<Product?> UpdateProductByIdAsync(UpdateProductCommand request)
    {
        var product = await _products.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (product == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }
        product = _mapper.Map(request, product);
        _dbContext.Entry(product).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return product;
    }
    
    public async Task<Product?> PatchProductByIdAsync(PatchProductCommand request)
    {
        var product = await _products.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (product == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }
        
        if (request.Name.Any())
            product.Name = request.Name;
            
        if (request.Description.Any())
            product.Description = request.Description;
            
        if (request.Amount > 0)
            product.Amount = request.Amount;
            
        if (request.Price > 0)
            product.Price = request.Price;
            
        if (request.TechnicalInformation.Any())
            product.TechnicalInformation = request.TechnicalInformation;
        
        _dbContext.Entry(product).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return product;
    }
    
    public async Task<Product?> PatchProductImageByIdAsync(PatchProductImageCommand request)
    {
        var product = await _products.Include(p => p.Photos).FirstOrDefaultAsync(p => p.Id == request.ProductId);
        if (product == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }
        var productPhoto = await _dbContext.ProductPhoto.FirstOrDefaultAsync(p => p.Id == request.PhotoId);
        if (productPhoto == null)
        {
            throw new NotFoundException("Foto do produto não encontrado");
        }
        if (request.Photo == null || request.Photo.Length == 0)
        {
            throw new BadRequestException("Você precisa enviar uma imagem");
        }
        var isImageValid = await IsImageValid(request.Photo);
        if (request.Photo != null && !isImageValid)
        {
            throw new BadRequestException("Esta não é uma imagem valida");
        }
        if (request.Photo != null && request.Photo.Length > 0)
        {
            const int maxFileSize = 5 * 1024 * 1024;
            if (request.Photo.Length > maxFileSize)
            {
                throw new BadRequestException("O tamanho máximo do arquivo é de 5 MB.");
            }
            var fileName = Guid.NewGuid() + Path.GetExtension(request.Photo.FileName);
            var imagePath = Path.Combine("uploads/products", fileName);
            await using var imageStream = request.Photo.OpenReadStream();
            using var image = await Image.LoadAsync(imageStream);
            await image.SaveAsync(imagePath);

            productPhoto.Name = request.Photo.FileName;
            productPhoto.NewName = fileName;
            productPhoto.Path = imagePath;
            productPhoto.UpdatedAt = DateTime.UtcNow;
            
            _dbContext.Entry(productPhoto).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        // await _dbContext.Entry(productPhoto).ReloadAsync();
        await _dbContext.Entry(product).ReloadAsync();
        product = await _products.Include(p => p.Photos).FirstOrDefaultAsync(p => p.Id == request.ProductId);
        return product;
    }
    
    public async Task<Product?> DeleteProductByIdAsync(DeleteProductCommand request)
    {
        var product = await _products.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (product == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }

        _products.Remove(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    private static void FilterByColumn(ref IQueryable<Product> products, GetProductsQuery requestParameter)
    {
        if (!products.Any())
            return;

        if (requestParameter is { Id: 0, Search: null })
            return;

        var predicate = PredicateBuilder.New<Product>();

        if (requestParameter.Id > 0)
            predicate = predicate.And(p => p.Id == requestParameter.Id);

        if (!string.IsNullOrEmpty(requestParameter.Search))
            predicate = predicate.And(p =>
                p.Name.Contains(requestParameter.Search.ToUpper().Trim()));

        if (requestParameter is { Id: 0, Search: "", OrderBy: "", Fields: "" })
        {
            predicate.And(x => true);
        }

        if (requestParameter is not { Fields: "" })
        {
            predicate.And(x => true);
        }

        products = products.Where(predicate);
    }
    
    private static async Task<bool> IsImageValid(IFormFile file)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (file == null || !allowedExtensions.Contains(fileExtension))
        {
            return false;
        }

        try
        {
            using var image = await Image.LoadAsync(file.OpenReadStream());
            return image is { Width: > 0, Height: > 0 };
        }
        catch (Exception)
        {
            return false;
        }
    }
}