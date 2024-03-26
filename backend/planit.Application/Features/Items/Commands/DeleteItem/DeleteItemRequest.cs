using MediatR;

namespace planit.Application.Features;
public class DeleteItemRequest: IRequest<Unit>
{
    public Guid ItemId { get; set; }

}
