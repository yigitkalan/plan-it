using MediatR;

namespace planit.Application.Features;
public class GetByBoardIdRequest: IRequest<GetByBoardIdResponse>
{
    public Guid BoardId {get; set;}

}
