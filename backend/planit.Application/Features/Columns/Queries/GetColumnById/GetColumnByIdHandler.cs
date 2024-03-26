using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetColumnByIdHandler : BaseHandler, IRequestHandler<GetColumnByIdRequest, GetColumnByIdResponse>
{
    public GetColumnByIdHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<GetColumnByIdResponse> Handle(GetColumnByIdRequest request, CancellationToken cancellationToken)
    {
        var column = await getter.GenericRepository<Column>().GetAsync(predicate: c => c.Id == request.ColumnId && !c.IsDeleted, include: q => q.Include(c => c.Tasks)) ?? throw new Exception("Column not found");

        return new GetColumnByIdResponse
        {
            Column = mapper.Map<Column, ColumnDto>(column),
            Tasks = column.Tasks.Select(t => mapper.Map<Item, ItemDto>(t)).ToList()
            
        };
    }
}
