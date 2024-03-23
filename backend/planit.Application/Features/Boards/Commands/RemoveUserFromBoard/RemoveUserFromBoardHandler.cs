using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Bases;
using planit.Application.Interfaces;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class RemoveUserFromBoardHandler :BaseHandler, IRequestHandler<RemoveUserFromBoardRequest, Unit>
{
    public RemoveUserFromBoardHandler(IRepositoryGetter repositoryGetter, IMapper mapper, IHttpContextAccessor
     httpContextAccessor) : base(mapper, repositoryGetter, httpContextAccessor)
    {

    }
    public async Task<Unit> Handle(RemoveUserFromBoardRequest request, CancellationToken cancellationToken)
    {

        var boardRepo = getter.GenericRepository<Board>();
        var userRepo = getter.GenericRepository<User>();

        var user = await userRepo.GetAsync(predicate: u => u.Id == request.UserId , enableTracking: true)
         ?? throw new Exception("User not found");

        var board = await boardRepo.GetAsync(predicate: b => b.Id == request.BoardId && !b.IsDeleted, enableTracking: true)
         ?? throw new Exception("Board not found");

        board.Users.Remove(user);
        await boardRepo.UpdateAsync(board);
        return Unit.Value;
    }
}
