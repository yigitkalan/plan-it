using MediatR;

namespace planit.Application.Features;
public class GetBoardByIdRequest : IRequest<GetBoardByIdResponse>
{
    public Guid BoardId { get; set; }
}
