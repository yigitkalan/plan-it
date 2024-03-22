using AutoMapper;
using MediatR;
using planit.Application.Interfaces;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class UpdateBoardHandler : IRequestHandler<UpdateBoardRequest, Unit>
{
    private IRepositoryGetter getter;
    private IMapper autoMapper;

    public UpdateBoardHandler(IRepositoryGetter getter, IMapper mapper)
    {
        this.getter = getter;
        this.autoMapper = mapper;

    }
    public async Task<Unit> Handle(UpdateBoardRequest request, CancellationToken cancellationToken)
    {
        var boardRepo = getter.GenericRepository<Board>();

        var board = await boardRepo.GetAsync(predicate: b => b.Id == request.Id, enableTracking: true) ?? throw new Exception("Board not found");

        autoMapper.Map(request, board);

        await boardRepo.UpdateAsync(board);
        return Unit.Value;
    }
}
