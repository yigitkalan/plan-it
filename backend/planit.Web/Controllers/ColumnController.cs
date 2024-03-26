using Microsoft.AspNetCore.Mvc;
using planit.Application.Features;

namespace planit.Web.Controllers;
public class ColumnController: BaseController
{

    [HttpGet]
    public async Task<IActionResult> GetByBoardId([FromQuery] Guid boardId){
        var response = await Mediator.Send(new GetByBoardIdRequest { BoardId = boardId }); 
        return Ok(response);
    }

    [HttpGet]
    //get all
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetAllColumnsRequest());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateColumnRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

}
