using MediatR;

namespace planit.Application.Features;
public class RemoveUserFromBoardRequest: IRequest<Unit>
{
    public Guid BoardId { get; set; }
    public Guid UserId { get; set; }
}
