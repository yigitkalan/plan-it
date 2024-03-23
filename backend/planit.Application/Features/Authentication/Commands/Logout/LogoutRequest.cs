using MediatR;

namespace planit.Application.Features;
public class LogoutRequest: IRequest<Unit>
{
    public string Email { get; set; }

}
