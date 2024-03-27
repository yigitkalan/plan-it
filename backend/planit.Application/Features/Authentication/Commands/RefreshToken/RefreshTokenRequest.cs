using MediatR;

namespace planit.Application.Features;
public class RefreshTokenRequest: IRequest<RefreshTokenResponse>
{
    public string AccessToken { get; set; }
}
