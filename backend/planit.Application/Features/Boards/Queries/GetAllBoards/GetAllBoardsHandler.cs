using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using planit.Application.Bases;
using planit.Application.Abstractions;
using planit.Domain.Entities;
using planit.Application.DTOs;

namespace planit.Application.Features;
public class GetAllBoardsHandler : BaseHandler, IRequestHandler<GetAllBoardsRequest, GetAllBoardsResponse>
{
    public GetAllBoardsHandler(IRepositoryGetter repositoryGetter, IMapper mapper, IHttpContextAccessor
     httpContextAccessor) : base(mapper, repositoryGetter, httpContextAccessor)
    {

    }
    public async Task<GetAllBoardsResponse> Handle(GetAllBoardsRequest request, CancellationToken cancellationToken)
    {
        var boards = await getter.GenericRepository<Board>().GetAllAsync(predicate: b => !b.IsDeleted);

        var response = new GetAllBoardsResponse
        {
            Boards = boards.Select(board => mapper.Map<Board, BoardDto>(board)).ToList()
        };

        return response;
    }
}
