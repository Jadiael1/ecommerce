using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

/// <summary>
/// 
/// </summary>
/// 
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private IMediator? _mediator;
    /// <summary>
    /// 
    /// </summary>
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}

