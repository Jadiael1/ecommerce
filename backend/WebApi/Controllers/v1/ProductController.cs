using Application.DTOs.Error;
using Application.DTOs.Product;
using Application.Exceptions;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.PatchProduct;
using Application.Features.Products.Commands.PatchProductImageCommand;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Queries.GetProducts;
using Application.Features.Products.Queries.GetProductsById;
using Application.Wrappers;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers.v1;

/// <summary>
/// 
/// </summary>
[ApiVersion("1.0")]
[Authorize(Roles = "admin, user")]
public class ProductController : BaseApiController
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }


    /// <summary>
    /// GET api/controller, CRUD > Get by query parameters
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<Product>>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> Get([FromQuery] GetProductsQuery filter)
    {
        return Ok(await Mediator!.Send(filter));
    }

    /// <summary>
    /// Get api/controller, CRUD > Get by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<Product>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await Mediator!.Send(new GetProductsByIdQuery { Id = id }));
    }

    /// <summary>
    /// POST api/controller, CRUD > Create
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response<Product>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> Post([FromForm] CreateProductCommand command)
    {
        var claimsPrincipal = HttpContext.User;
        if (claimsPrincipal.Claims.Any() && int.TryParse(claimsPrincipal.Claims.First().Value, out var userId))
        {
            command.UserId = userId;
        }
        return CreatedAtAction(nameof(Post), await Mediator!.Send(command));
    }
    
    /// <summary>
    /// PUT api/controller, CRUD > Update
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<Product>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> PutAsync(int id, UpdateProductCommand command)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        command.Id = id;
        return Ok(await Mediator!.Send(command));
    }
    
    /// <summary>
    /// PATCH api/controller, CRUD > Partially update
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<Product>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> PatchAsync(int id, PatchProductCommand command)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        command.Id = id;
        return Ok(await Mediator!.Send(command));
    }
    
    /// <summary>
    /// PATCH api/controller, CRUD > Update product photo
    /// </summary>
    /// <param name="command"></param>
    /// <param name="productId"></param>
    /// <param name="photoId"></param>
    /// <returns></returns>
    [HttpPatch("{productId:int}/photo/{photoId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<Product>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> PatchProductImageAsync([FromForm] RequestUpdateImageCommandDto command, int productId, int photoId)
    {
        var patchProductImageCommand = new PatchProductImageCommand
        {
            Photo = command.Photo,
            PhotoId = photoId,
            ProductId = productId
        };
        return Ok(await Mediator!.Send(patchProductImageCommand));
    }
    
    /// <summary>
    /// DELETE api/controller, CRUD > Delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<Product>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        return Ok(await Mediator!.Send(new DeleteProductCommand { Id = id }));
    }
    
}