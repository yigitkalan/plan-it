using MediatR;

namespace planit.Application.Features;
public class AddUserToBoardRequest: IRequest<Unit>
{
    public Guid BoardId { get; set; }
    public Guid UserId { get; set; }

}
