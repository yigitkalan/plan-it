using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace planit.Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController: ControllerBase
{
    private IMediator _mediator = null!;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


}
