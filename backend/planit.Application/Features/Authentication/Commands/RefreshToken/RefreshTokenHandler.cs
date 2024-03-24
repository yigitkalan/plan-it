using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using planit.Application.Bases;
using planit.Application.Abstractions;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class RefreshTokenHandler : BaseHandler, IRequestHandler<RefreshTokenRequest, RefreshTokenResponse>
{
    private UserManager<User> userManager;
    private IJWTService jwtService;

    //add usermanager and jwtservice to constructor
    public RefreshTokenHandler(UserManager<User> userManager, IJWTService jWTService, IMapper mapper, IRepositoryGetter repositoryGetter, IHttpContextAccessor
     httpContextAccessor) : base(mapper, repositoryGetter, httpContextAccessor)
    {
        this.userManager = userManager;
        this.jwtService = jWTService;
    }
    public async Task<RefreshTokenResponse> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var principal = jwtService.GetPrincipalFromExpiredToken(request.AccessToken);
        var email = principal.FindFirstValue(ClaimTypes.Email);

        var user = userManager.FindByEmailAsync(email).Result;
        var roles = userManager.GetRolesAsync(user).Result;

        if(user.RefreshTokenExpiration < DateTime.Now)
        {
            throw new Exception("Refresh token has expired");
        }

        JwtSecurityToken newAccessToken = await jwtService.GenerateToken(user, roles);
        var newRefreshToken = jwtService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await userManager.UpdateAsync(user);

        return new(){
            AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
            RefreshToken = newRefreshToken
        };

    }
}
