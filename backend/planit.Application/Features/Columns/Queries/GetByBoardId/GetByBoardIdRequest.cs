using MediatR;

namespace planit.Application.Features;
public class GetByBoardIdRequest: IRequest<List<GetByBoardIdResponse>>
{
    public Guid BoardId {get; set;}

}
