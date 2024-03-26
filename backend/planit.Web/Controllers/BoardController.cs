using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using planit.Application.Features;

namespace planit.Web.Controllers;
// [Authorize]
public class BoardController: BaseController
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetAllBoardsRequest());
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery]Guid id){
        var response = await Mediator.Send(new GetBoardByIdRequest { BoardId = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetByUser([FromQuery] Guid id){
        var response = await Mediator.Send(new GetBoardsByUserIdRequest { UserId = id }); 
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
