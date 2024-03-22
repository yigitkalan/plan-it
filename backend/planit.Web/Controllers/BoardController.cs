using Microsoft.AspNetCore.Mvc;
using planit.Application.Features;

namespace planit.Web.Controllers;
public class BoardController: BaseController
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetAllBoardsRequest());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBoardRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteBoardRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBoardRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> AddUser([FromBody] AddUserToBoardRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> RemoveUser([FromBody] RemoveUserFromBoardRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}
