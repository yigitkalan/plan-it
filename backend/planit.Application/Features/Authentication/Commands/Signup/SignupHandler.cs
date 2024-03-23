using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using planit.Application.Bases;
using planit.Application.Interfaces;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class SignupHandler : BaseHandler, IRequestHandler<SignupRequest, Unit>
{
    private readonly UserManager<User> userManager;
    private readonly AuthenticationRules authRules;
    private readonly RoleManager<Role> roleManager;

    public SignupHandler(AuthenticationRules authRules,RoleManager<Role> roleManager, UserManager<User> userManager, IMapper mapper, IRepositoryGetter repositoryGetter, IHttpContextAccessor
     httpContextAccessor) : base(mapper, repositoryGetter, httpContextAccessor)
    {
        this.userManager = userManager;
        this.authRules = authRules;
        this.roleManager = roleManager;
    }
    public async Task<Unit> Handle(SignupRequest request, CancellationToken cancellationToken)
    {
        await authRules.UserShouldNotExist(await userManager.FindByEmailAsync(request.Email));

        User user = autoMapper.Map<SignupRequest, User>(request);
        user.SecurityStamp = Guid.NewGuid().ToString();
        IdentityResult identityResult = await userManager.CreateAsync(user, request.Password);
        if(identityResult.Succeeded){
            if(!await roleManager.RoleExistsAsync("User")){
                await roleManager.CreateAsync(new Role(){
                    Id = Guid.NewGuid(),
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            }
            await userManager.AddToRoleAsync(user, "User");
        }

        return Unit.Value;
    }
}
