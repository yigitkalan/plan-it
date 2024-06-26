using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Bases;
using planit.Application.Abstractions;
using planit.Domain.Entities;
using planit.Application.DTOs;

namespace planit.Application.Features;
public class UpdateBoardHandler :BaseHandler, IRequestHandler<UpdateBoardRequest, UpdateBoardResponse>
{
    public UpdateBoardHandler(IRepositoryGetter repositoryGetter, IMapper mapper, IHttpContextAccessor
     httpContextAccessor) : base(mapper, repositoryGetter, httpContextAccessor)
    {

    }
    public async Task<UpdateBoardResponse> Handle(UpdateBoardRequest request, CancellationToken cancellationToken)
    {
        var boardRepo = getter.GenericRepository<Board>();

        var board = await boardRepo.GetAsync(predicate: b => b.Id == request.Id, enableTracking: true) ?? throw new Exception("Board not found");

        mapper.Map(request, board);

        await boardRepo.UpdateAsync(board);

        return new UpdateBoardResponse
        {
            board = mapper.Map<Board, BoardDto>(board)
        };
    }
}
