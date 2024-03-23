using MediatR;

namespace planit.Application.Features;
public class SigninRequest : IRequest<SigninResponse> 
{
    public string Email { get; set; }
    public string Password { get; set; }

}
