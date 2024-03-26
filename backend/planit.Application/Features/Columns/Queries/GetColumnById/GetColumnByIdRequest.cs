using MediatR;

namespace planit.Application.Features;

public class GetColumnByIdRequest: IRequest<GetColumnByIdResponse>
{
    public Guid ColumnId { get; set; }
}
