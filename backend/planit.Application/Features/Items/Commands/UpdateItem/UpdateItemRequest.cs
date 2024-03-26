using MediatR;
using planit.Application.DTOs;

namespace planit.Application.Features;
public class UpdateItemRequest: IRequest<UpdateItemResponse>
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ColumnId { get; set; }
}
