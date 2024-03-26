using MediatR;

namespace planit.Application.Features;
public class GetItemByIdRequest: IRequest<GetItemByIdResponse>
{
    public Guid ItemId { get; set; }

}
