using MediatR;

namespace planit.Application.Features;
public class GetItemsByColumnIdRequest: IRequest<GetItemsByColumnIdResponse>
{
    public Guid ColumnId { get; set; }
}
