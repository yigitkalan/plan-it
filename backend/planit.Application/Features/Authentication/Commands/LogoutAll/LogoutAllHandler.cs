using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using planit.Application.Bases;
using planit.Application.Interfaces;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class LogoutAllHandler :BaseHandler, IRequestHandler<LogoutAllRequest, Unit>
{

    private AuthenticationRules authRules;
    private UserManager<User> userManager;

    public LogoutAllHandler(AuthenticationRules authRules, UserManager<User> userManager, IMapper mapper, IRepositoryGetter repositoryGetter, IHttpContextAccessor
     httpContextAccessor) : base(mapper, repositoryGetter, httpContextAccessor)
    {
        this.authRules = authRules;
        this.userManager = userManager;
    }
    public async Task<Unit> Handle(LogoutAllRequest request, CancellationToken cancellationToken)
    {
        List<User> users = userManager.Users.ToList();
        users.ForEach(async user =>
        {
            user.RefreshToken = null;
            user.RefreshTokenExpiration = null;
            await userManager.UpdateAsync(user);
        });

        return Unit.Value;
    }
}
