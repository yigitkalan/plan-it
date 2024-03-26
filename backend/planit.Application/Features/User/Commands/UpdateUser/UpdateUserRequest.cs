using MediatR;

namespace planit.Application.Features;
public class UpdateUserRequest: IRequest<UpdateUserResponse>
{

    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }

}
