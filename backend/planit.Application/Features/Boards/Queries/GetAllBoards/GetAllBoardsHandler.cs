using MediatR;
using planit.Application.Interfaces;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetAllBoardsHandler : IRequestHandler<GetAllBoardsRequest, List<GetAllBoardsResponse>>
{
    private IGenericRepository<Board> repository;

    public GetAllBoardsHandler(IGenericRepository<Board> repository)
    {
        this.repository = repository;

    }
    public async Task<List<GetAllBoardsResponse>> Handle(GetAllBoardsRequest request, CancellationToken cancellationToken)
    {
        var boards = await repository.GetAllAsync();

        List<GetAllBoardsResponse> response = boards.Select(board => new GetAllBoardsResponse{
            Name = board.Name,
            OwnerId = board.OwnerId
        }).ToList();
        return response;
    }
}
