using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetByBoardIdHandler : BaseHandler, IRequestHandler<GetByBoardIdRequest, GetByBoardIdResponse>
{
    public GetByBoardIdHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<GetByBoardIdResponse> Handle(GetByBoardIdRequest request, CancellationToken cancellationToken)
    {
        var board = await getter.GenericRepository<Board>().GetAsync(b => b.Id == request.BoardId && !b.IsDeleted) ?? throw new Exception("Board not found");

        List<Column> columns = await getter.GenericRepository<Column>()
        .GetAllAsync(b => b.BoardId == request.BoardId && !b.IsDeleted, include: q => q.Include(c => c.Tasks), orderBy: q => q.OrderBy(c => c.Order));

        return new GetByBoardIdResponse
        {
            Columns = columns.Select(mapper.Map<Column, ColumnDto>).ToList()
        };
    }
}
