using MediatR;

namespace planit.Application.Features;
public class CreateItemRequest: IRequest<CreateItemResponse>
{
    public int Order { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ColumnId { get; set; }
}
