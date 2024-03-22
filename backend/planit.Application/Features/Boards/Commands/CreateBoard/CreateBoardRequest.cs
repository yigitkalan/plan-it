using MediatR;

namespace planit.Application.Features;
public class CreateBoardRequest: IRequest<Unit>
{
    public string Name { get; set; }
    public int OwnerId { get; set; }

}
