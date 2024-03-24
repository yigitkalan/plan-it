using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Bases;
using planit.Application.Abstractions;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class DeleteBoardHandler : BaseHandler, IRequestHandler<DeleteBoardRequest, Unit>
{
    public DeleteBoardHandler(IRepositoryGetter repositoryGetter, IMapper mapper, IHttpContextAccessor
     httpContextAccessor) : base(mapper, repositoryGetter, httpContextAccessor)
    {

    }
    public async Task<Unit> Handle(DeleteBoardRequest request, CancellationToken cancellationToken)
    {
        var repo = getter.GenericRepository<Board>();
        var board = await repo.GetAsync(predicate: b => b.Id == request.Id, enableTracking: true)
                 ?? throw new Exception("Board not found");
        board.IsDeleted = true;
        await repo.UpdateAsync(board);
        return Unit.Value;
    }
}
