using MediatR;

namespace planit.Application.Features;
public class DeleteUserRequest: IRequest<Unit>
{
   public Guid Id { get; set; } 
}
