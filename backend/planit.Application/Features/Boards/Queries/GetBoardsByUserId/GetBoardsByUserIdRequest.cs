using MediatR;

namespace planit.Application.Features;
public class GetBoardsByUserIdRequest: IRequest<GetBoardsByUserIdResponse>
{
    public Guid UserId { get; set; }

}
