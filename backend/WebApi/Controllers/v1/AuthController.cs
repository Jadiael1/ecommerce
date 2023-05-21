using Application.DTOs.Error;
using Application.DTOs.SignIn;
using Application.Features.Authentication.Commands;
using Application.Wrappers;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<ResponseSignInDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResponseErrorDto))]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
    {
        var user = await AuthenticationRepositoryAsync.SignIn(command, _context);
        command.User = user;
        command.Token = TokenService.GenerateToken(user);
        var resp = await Mediator!.Send(command);
        return Ok(resp);
    }
}