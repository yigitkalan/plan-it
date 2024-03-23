using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using planit.Application.Interfaces;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class CreateBoardHandler : IRequestHandler<CreateBoardRequest, Unit>
{

    private IRepositoryGetter getter;
    private IMapper autoMapper;

    public CreateBoardHandler(IRepositoryGetter getter, IMapper mapper)
    {
        this.getter = getter;
        this.autoMapper = mapper;

    }
    public async Task<Unit> Handle(CreateBoardRequest request, CancellationToken cancellationToken)
    {
        var board = autoMapper.Map<CreateBoardRequest, Board>(request);
        var user = await getter.GenericRepository<User>()
        .GetAsync(predicate: u => u.Id == request.OwnerId,
        include: q => q.Include(u => u.ParticipatedBoards), enableTracking: true)
         ?? throw new Exception("User not found");
        board.Users.Add(user);

        await getter.GenericRepository<Board>().AddAsync(board);
        await getter.GenericRepository<User>().UpdateAsync(user);

        return Unit.Value;

    }
}
