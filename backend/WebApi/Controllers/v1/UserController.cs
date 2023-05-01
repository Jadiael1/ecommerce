using Application.DTOs.Error;
using Application.Exceptions;
using Application.Features.Users.Queries.GetUserById;
using Application.Features.Users.Queries.GetUsers;
using Application.Wrappers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1;

/// <summary>
/// 
/// </summary>
[ApiVersion("1.0")]
public class UserController : BaseApiController
{
    /// <summary>
    /// GET: api/controller, CRUD > Get by query parameters
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<User>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> Get([FromQuery] GetUsersQuery filter)
    {
        return Ok(await Mediator!.Send(filter));
    }

    /// <summary>
    /// GET api/controller, CRUD > Get by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<User>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await Mediator!.Send(new GetUserByIdQuery { Id = id }));
    }

    /// <summary>
    /// POST api/controller, CRUD > Create
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Post(User user)
    {
        await Task.Delay(1000);
        return new { };
    }

    /// <summary>
    /// Get User By ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<object> PutAsync(int id, User user)
    {
        await Task.Delay(1000);
        return new { };
    }

    // DELETE: api/TodoItems/5
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task<object> DeleteUser(int id)
    {
        await Task.Delay(1000);
        return new { };
    }
}