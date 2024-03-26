using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class UpdateColumnHandler : BaseHandler, IRequestHandler<UpdateColumnRequest, UpdateColumnResponse>
{
    public UpdateColumnHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<UpdateColumnResponse> Handle(UpdateColumnRequest request, CancellationToken cancellationToken)
    {
        var column = await getter.GenericRepository<Column>().GetAsync(predicate: c => c.Id == request.ColumnId && !c.IsDeleted, enableTracking: true) ?? throw new Exception("Column not found");

        column.Name = request.Name;

        await getter.GenericRepository<Column>().UpdateAsync(column);
        return new UpdateColumnResponse
        {
            Column = mapper.Map<Column, ColumnDto>(column)
        };



    }
}
