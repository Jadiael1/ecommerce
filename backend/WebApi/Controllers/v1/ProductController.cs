using Application.DTOs.Error;
using Application.Features.Products.Queries.GetProducts;
using Application.Features.Products.Queries.GetProductsById;
using Application.Wrappers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1;
/// <summary>
/// 
/// </summary>
[ApiVersion("1.0")]
public class ProductController : BaseApiController
{
    /// <summary>
    /// GET api/controller, CRUD > Get by query parameters
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<Product>>))]
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
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await Mediator!.Send(new GetProductsByIdQuery { Id = id }));
    }
}