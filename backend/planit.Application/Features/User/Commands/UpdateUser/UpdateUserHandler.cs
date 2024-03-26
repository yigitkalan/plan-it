using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class UpdateUserHandler :BaseHandler, IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    UserManager<User> userManager;

    public UpdateUserHandler(UserManager<User> userManager, IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
        this.userManager = userManager;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString())
        ?? throw new Exception("User not found");

        user.Email = request.Email;
        user.UserName = request.Username;
        user.EmailConfirmed = true;
        user.SecurityStamp = Guid.NewGuid().ToString();
        await userManager.UpdateAsync(user);
        return new UpdateUserResponse
        {
            User = mapper.Map<User, UserDto>(user)
        };
    }
}
