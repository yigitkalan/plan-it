using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using planit.Application.Interfaces;
using planit.Domain.Entities;

namespace planit.Persistance.Tokens;
public class JWTService : IJWTService
{

    private readonly UserManager<User> userManager;
    private readonly JWTConfiguration jwtConfiguration;


    public JWTService(IOptions<JWTConfiguration> options, UserManager<User> userManager)
    {
        this.userManager = userManager;
        jwtConfiguration = options.Value;
    }
    public string GenerateRefreshToken()
    {

        throw new NotImplementedException();
    }

    public async Task<JwtSecurityToken> GenerateToken(User user, List<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email) };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Secret));

        var token = new  JwtSecurityToken(
            issuer: jwtConfiguration.Issuer,
            audience: jwtConfiguration.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(jwtConfiguration.AccessTokenExpiration),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        await userManager.AddClaimsAsync(user, claims);

        return token;
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        throw new NotImplementedException();
    }
}
