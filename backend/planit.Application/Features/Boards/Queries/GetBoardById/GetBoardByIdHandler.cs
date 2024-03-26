using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetBoardByIdHandler : BaseHandler, IRequestHandler<GetBoardByIdRequest, GetBoardByIdResponse>
{
    public GetBoardByIdHandler(IMapper mapper, IRepositoryGetter repositoryGetter, IHttpContextAccessor httpContextAccessor) : base(mapper, repositoryGetter, httpContextAccessor)
    {
    }

    public async Task<GetBoardByIdResponse> Handle(GetBoardByIdRequest request, CancellationToken cancellationToken)
    {
        Board board = await getter.GenericRepository<Board>()
        .GetAsync(predicate: b => b.Id == request.BoardId && !b.IsDeleted, q => q.Include(b => b.Columns));

        var resp = new GetBoardByIdResponse
        {
            board = mapper.Map<Board, BoardDto>(board),
            Columns = mapper.Map<List<Column>, List<ColumnDto>>(board.Columns.ToList())
        };

        return resp;
    }
}
