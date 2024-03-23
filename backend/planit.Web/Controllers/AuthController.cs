using Microsoft.AspNetCore.Mvc;
using planit.Application.Features;
using planit.Web.Controllers;

namespace planit.Web.Controllers;
public class AuthController: BaseController
{

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var response = await Mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created);
    }

}
