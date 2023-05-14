using Application.DTOs.Error;
using Application.Features.Authentication.Commands;
using Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers.v1;

/// <summary>
/// 
/// </summary>
[ApiVersion("1.0")]
public class AuthController : BaseApiController
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// POST api/controller, SignIn
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SignInCommand))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResponseErrorDto))]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
    {
        // var user = await SignInRepositoryAsync.GetUserApiAsync(command, _context);
        // command.Matricula = user.Id;
        // command.UserName = user.UserName;
        // command.Role = user.Role;
        // command.Token = TokenService.GenerateToken(user);
        var resp = await Mediator!.Send(command);
        return Ok(resp);
    }
}