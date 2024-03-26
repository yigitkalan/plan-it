using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using planit.Application.Bases;
using planit.Application.Abstractions;
using planit.Domain.Entities;
using planit.Application.DTOs;

namespace planit.Application.Features;
public class CreateBoardHandler : BaseHandler, IRequestHandler<CreateBoardRequest, CreateBoardResponse>
{


    public CreateBoardHandler(IMapper autoMapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(autoMapper, getter, httpContextAccessor)
    {

    }
    public async Task<CreateBoardResponse> Handle(CreateBoardRequest request, CancellationToken cancellationToken)
    {
        Board board = mapper.Map<CreateBoardRequest, Board>(request);
        var user = await getter.GenericRepository<User>()
        .GetAsync(predicate: u => u.Id == request.OwnerId,
        include: q => q.Include(u => u.ParticipatedBoards), enableTracking: true)
         ?? throw new Exception("User not found");
        board.Users.Add(user);

        await getter.GenericRepository<Board>().AddAsync(board);
        await getter.GenericRepository<User>().UpdateAsync(user);

        return new CreateBoardResponse
        {
            board = mapper.Map<Board, BoardDto>(board)
        };

    }
}
