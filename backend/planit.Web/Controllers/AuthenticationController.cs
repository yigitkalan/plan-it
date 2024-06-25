using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using planit.Application.Features;
using planit.Web.Controllers;

namespace planit.Web.Controllers;
public class AuthenticationController: BaseController
{

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] SignupRequest request)
    {
        var response = await Mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] SigninRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Revoke([FromBody] LogoutRequest request)
    {
        await Mediator.Send(request);
        return Ok();
    }
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RevokeAll()
    {
        await Mediator.Send(new LogoutAllRequest());
        return Ok();
    }

}
