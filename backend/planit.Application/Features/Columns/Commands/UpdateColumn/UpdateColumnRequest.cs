using MediatR;

namespace planit.Application.Features;
public class UpdateColumnRequest: IRequest<UpdateColumnResponse>
{
    public Guid ColumnId { get; set; }
    public int Order { get; set; }
    public string Name { get; set; }
}
