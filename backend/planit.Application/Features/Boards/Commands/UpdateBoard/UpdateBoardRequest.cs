using MediatR;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class UpdateBoardRequest: IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int OwnerId { get; set; }

}
