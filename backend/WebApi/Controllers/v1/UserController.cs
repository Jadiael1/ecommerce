using Application.DTOs.Error;
using Application.DTOs.User;
using Application.Exceptions;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.DeleteUser;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Queries.GetUserById;
using Application.Features.Users.Queries.GetUsers;
using Application.Wrappers;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1;

/// <summary>
/// 
/// </summary>
[ApiVersion("1.0")]
// [Authorize(Roles = "admin, user")]
public class UserController : BaseApiController
{
    /// <summary>
    /// GET api/controller, CRUD > Get by query parameters
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<IEnumerable<ResponseUserDto>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> Get([FromQuery] GetUsersQuery filter)
    {
        return Ok(await Mediator!.Send(filter));
    }

    /// <summary>
    /// Get api/controller, CRUD > Get by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<ResponseUserDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorDto))]
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
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response<User>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> Post(CreateUserCommand command)
    {
        return CreatedAtAction(nameof(Post), await Mediator!.Send(command));
    }

    /// <summary>
    /// PUT api/controller, CRUD > Update
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<User>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> PutAsync(int id, UpdateUserCommand command)
    {
        command.Id = id;
        return Ok(await Mediator!.Send(command));
    }

    /// <summary>
    /// DELETE api/controller, CRUD > Delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<User>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorDto))]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        return Ok(await Mediator!.Send(new DeleteUserCommand { Id = id }));
    }
}