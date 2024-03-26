using MediatR;

namespace planit.Application.Features;
public class DeleteColumnRequest: IRequest<Unit>
{
    public Guid ColumnId { get; set; }

}
