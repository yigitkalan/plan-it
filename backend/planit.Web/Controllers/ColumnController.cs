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
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetAllColumnsRequest());
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery]Guid id){
        var response = await Mediator.Send(new GetColumnByIdRequest { ColumnId = id });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateColumnRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateColumnRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteColumnRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }


}
