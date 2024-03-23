using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using planit.Application.Bases;
using planit.Application.Interfaces;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class LogoutHandler : BaseHandler, IRequestHandler<LogoutRequest, Unit>
{
    private AuthenticationRules authRules;
    private UserManager<User> userManager;

    public LogoutHandler(AuthenticationRules authRules, UserManager<User> userManager, IMapper mapper, IRepositoryGetter repositoryGetter, IHttpContextAccessor
     httpContextAccessor) : base(mapper, repositoryGetter, httpContextAccessor)
    {
        this.authRules = authRules;
        this.userManager = userManager;
    }
    public async Task<Unit> Handle(LogoutRequest request, CancellationToken cancellationToken)
    {
        User user = userManager.FindByEmailAsync(request.Email).Result;
        await authRules.UserShouldExist(user);

        user.RefreshToken = null;
        user.RefreshTokenExpiration = null;
        await userManager.UpdateAsync(user);

        return Unit.Value;
    }
}
