using MediatR;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class UpdateBoardRequest: IRequest<UpdateBoardResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

}
