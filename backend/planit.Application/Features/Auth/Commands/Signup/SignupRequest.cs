using MediatR;

namespace planit.Application.Features;
public class SignupRequest: IRequest<Unit>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Username { get; set; }
}
