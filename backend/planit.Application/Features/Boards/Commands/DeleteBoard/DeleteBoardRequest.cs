using MediatR;

namespace planit.Application.Features;
public class DeleteBoardRequest: IRequest<Unit>
{
    public Guid Id { get; set; }

}
