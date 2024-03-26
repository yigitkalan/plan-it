using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class DeleteUserHandler : BaseHandler, IRequestHandler<DeleteUserRequest, Unit>
{
    UserManager<User> userManager;
    public DeleteUserHandler(UserManager<User> userManager, IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
        this.userManager = userManager;
    }

    public async Task<Unit> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user  = await userManager.FindByIdAsync(request.Id.ToString());
        if(user == null){
            throw new Exception("User not found");
        }
        await userManager.DeleteAsync(user);
        return Unit.Value;
    }
}
