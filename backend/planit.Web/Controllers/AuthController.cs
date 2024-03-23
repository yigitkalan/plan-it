using Microsoft.AspNetCore.Mvc;
using planit.Application.Features;
using planit.Web.Controllers;

namespace planit.Web.Controllers;
public class AuthController: BaseController
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

}
