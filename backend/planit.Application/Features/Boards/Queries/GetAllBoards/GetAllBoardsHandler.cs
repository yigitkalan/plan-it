using AutoMapper;
using MediatR;
using planit.Application.Interfaces;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetAllBoardsHandler : IRequestHandler<GetAllBoardsRequest, List<GetAllBoardsResponse>>
{
    private IGenericRepository<Board> repository;
    private IMapper autoMapper;

    public GetAllBoardsHandler(IGenericRepository<Board> repository, IMapper mapper)
    {
        this.repository = repository;
        this.autoMapper = mapper;

    }
    public async Task<List<GetAllBoardsResponse>> Handle(GetAllBoardsRequest request, CancellationToken cancellationToken)
    {
        var boards = await repository.GetAllAsync();
        return autoMapper.Map<List<Board>, List<GetAllBoardsResponse>>(boards);;
    }
}
