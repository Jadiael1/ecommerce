using Application.Features.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entities;

namespace WebApi.Controllers.v1;

/// <summary>
/// 
/// </summary>
[ApiVersion("1.0")]
public class UserController : BaseApiController
{
    /// <summary>
    /// Get Users
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<object> GetUsers([FromQuery] GetUsersQuery filter)
    {
        return Ok(await Mediator.Send(filter));
    }

    /// <summary>
    /// Get User By ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<object> GetUserByID(int id)
    {
        await Task.Delay(1000);
        return new { };
    }

    /// <summary>
    /// Register a new user
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<object> PostAsync(User user)
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
