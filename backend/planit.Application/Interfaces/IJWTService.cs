using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using planit.Domain.Entities;

namespace planit.Application.Interfaces;
public interface IJWTService
{
    Task<JwtSecurityToken> GenerateToken(User user, IList<string> roles);
    string GenerateRefreshToken();

    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
