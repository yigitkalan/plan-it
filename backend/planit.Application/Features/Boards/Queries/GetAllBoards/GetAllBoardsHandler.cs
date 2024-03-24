using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using planit.Application.Bases;
using planit.Application.Abstractions;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetAllBoardsHandler :BaseHandler, IRequestHandler<GetAllBoardsRequest, List<GetAllBoardsResponse>>
{
    public GetAllBoardsHandler(IRepositoryGetter repositoryGetter, IMapper mapper, IHttpContextAccessor
     httpContextAccessor) : base(mapper, repositoryGetter, httpContextAccessor)
    {

    }
    public async Task<List<GetAllBoardsResponse>> Handle(GetAllBoardsRequest request, CancellationToken cancellationToken)
    {
        var boards = await getter.GenericRepository<Board>().GetAllAsync(include: q => q.Include(b => b.Users));
        return autoMapper.Map<List<Board>, List<GetAllBoardsResponse>>(boards);;
    }
}
