using MediatR;

namespace planit.Application.Features;
public class RemoveUserFromBoardRequest: IRequest<Unit>
{
    public int BoardId { get; set; }
    public int UserId { get; set; }
}
