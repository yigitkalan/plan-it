using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
{
    UserManager<User> userManager;
    public GetAllUsersHandler(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }
    public Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var users = new GetAllUsersResponse()
        {
            Users = userManager.Users.Include(u => u.ParticipatedBoards).ToList()
        };
        return Task.FromResult(users);
    }
}
