using MediatR;
using Microsoft.AspNetCore.Identity;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
{
    UserManager<User> userManager;
    public GetUserByIdHandler(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }
    public Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        User user = userManager.FindByIdAsync(request.Id).Result;
        return Task.FromResult(new GetUserByIdResponse() { User = user });
    }
}
