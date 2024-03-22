using MediatR;

namespace planit.Application.Features;
public class DeleteBoardRequest: IRequest<Unit>
{
    public int Id { get; set; }

}
