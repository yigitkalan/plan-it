using Microsoft.AspNetCore.Mvc;
using planit.Application.Features;

namespace planit.Web.Controllers;
public class ItemController: BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetByColumnId([FromQuery] Guid columnId){
        var response = await Mediator.Send(new GetItemsByColumnIdRequest { ColumnId = columnId }); 
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetAllItemsRequest());
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery]Guid id){
        var response = await Mediator.Send(new GetItemByIdRequest { ItemId = id });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateItemRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateItemRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteItemRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}
