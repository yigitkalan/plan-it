using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class CreateColumnHandler : BaseHandler, IRequestHandler<CreateColumnRequest, CreateColumnResponse>
{
    private ColumnRules columnRules;

    public CreateColumnHandler(ColumnRules columnRules, IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
        this.columnRules = columnRules;
    }

    public async Task<CreateColumnResponse> Handle(CreateColumnRequest request, CancellationToken cancellationToken)
    {
        var board = await getter.GenericRepository<Board>().GetAsync(predicate: b => b.Id == request.BoardId && !b.IsDeleted) ?? throw new BoardNotFoundException();

        Column column  = mapper.Map<CreateColumnRequest, Column>(request);
        await getter.GenericRepository<Column>().AddAsync(column);

        return new CreateColumnResponse
        {
            Column = mapper.Map<Column, ColumnDto>(column)
        };

    }
}
