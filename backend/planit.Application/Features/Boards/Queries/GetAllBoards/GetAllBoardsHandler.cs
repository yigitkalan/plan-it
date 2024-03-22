using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using planit.Application.Interfaces;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetAllBoardsHandler : IRequestHandler<GetAllBoardsRequest, List<GetAllBoardsResponse>>
{
    private IRepositoryGetter getter;
    private IMapper autoMapper;

    public GetAllBoardsHandler(IRepositoryGetter repository, IMapper mapper)
    {
        this.getter = repository;
        this.autoMapper = mapper;

    }
    public async Task<List<GetAllBoardsResponse>> Handle(GetAllBoardsRequest request, CancellationToken cancellationToken)
    {
        var boards = await getter.GenericRepository<Board>().GetAllAsync(include: q => q.Include(b => b.Users));
        return autoMapper.Map<List<Board>, List<GetAllBoardsResponse>>(boards);;
    }
}
