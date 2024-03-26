using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetAllColumnsHandler :BaseHandler, IRequestHandler<GetAllColumnsRequest, GetAllColumnsResponse>
{
    public GetAllColumnsHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<GetAllColumnsResponse> Handle(GetAllColumnsRequest request, CancellationToken cancellationToken)
    {
        List<Column> columns = await getter.GenericRepository<Column>().GetAllAsync(predicate: b => !b.IsDeleted, orderBy: q => q.OrderBy(c => c.Order));
        var res = new GetAllColumnsResponse(){
            Columns = columns.Select(mapper.Map<Column, ColumnDto>).ToList()
        };

        return res;

    }
}
