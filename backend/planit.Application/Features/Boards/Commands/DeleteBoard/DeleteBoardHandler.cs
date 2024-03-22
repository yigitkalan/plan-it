using AutoMapper;
using MediatR;
using planit.Application.Interfaces;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class DeleteBoardHandler : IRequestHandler<DeleteBoardRequest, Unit>
{
    private IRepositoryGetter getter;
    private IMapper autoMapper;

    public DeleteBoardHandler(IRepositoryGetter getter, IMapper mapper)
    {
        this.getter = getter;
        this.autoMapper = mapper;

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
