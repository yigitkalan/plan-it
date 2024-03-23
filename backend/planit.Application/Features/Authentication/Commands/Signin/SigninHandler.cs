using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using planit.Application.Bases;
using planit.Application.Interfaces;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class SigninHandler : BaseHandler, IRequestHandler<SigninRequest, SigninResponse>
{
    private readonly UserManager<User> userManager;
    private readonly AuthenticationRules authRules;
    private readonly IConfiguration configuration;
    private readonly IJWTService jwtService;

    public SigninHandler(IConfiguration configuration,IJWTService jwtService, AuthenticationRules authRules, UserManager<User> userManager, IMapper mapper, IRepositoryGetter repositoryGetter, IHttpContextAccessor
     httpContextAccessor) : base(mapper, repositoryGetter, httpContextAccessor)
    {
        this.configuration = configuration;
        this.jwtService = jwtService;
        this.userManager = userManager;
        this.authRules = authRules;
    }
    public async Task<SigninResponse> Handle(SigninRequest request, CancellationToken cancellationToken)
    {
        User user = await userManager.FindByEmailAsync(request.Email);
        await authRules.UserShouldExist(user);

        bool isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);

        await authRules.EmailAndPasswordShouldBeValid(user, isPasswordValid);

        IList<string> list = await userManager.GetRolesAsync(user);

        JwtSecurityToken jwtSecurityToken = await jwtService.GenerateToken(user, list);
        string refreshToken = jwtService.GenerateRefreshToken();

        _ = int.TryParse(configuration["JWT:RefreshExpirationInDays"], out int refreshTokenExpiration);
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiration = DateTime.Now.AddDays(refreshTokenExpiration);

        await userManager.UpdateAsync(user);
        await userManager.UpdateSecurityStampAsync(user);

        string tokenStr = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", tokenStr);

        return new SigninResponse()
        {
            Token = tokenStr,
            RefreshToken = refreshToken,
            Expires = jwtSecurityToken.ValidTo
        };
    }
}
