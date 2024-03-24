using Microsoft.AspNetCore.Mvc;
using planit.Application.Features;
using planit.Web.Controllers;

namespace planit.Web.Controllers;
public class UserController: BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetAllUsersRequest());
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] GetUserByIdRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

}
