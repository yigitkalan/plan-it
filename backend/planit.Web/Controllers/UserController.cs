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
    public async Task<IActionResult> GetById([FromQuery] string id)
    {
        var response = await Mediator.Send(new GetUserByIdRequest { Id = id });
        return Ok(response);
    }

}
