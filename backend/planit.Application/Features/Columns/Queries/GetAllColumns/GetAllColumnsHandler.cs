using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetAllColumnsHandler :BaseHandler, IRequestHandler<GetAllColumnsRequest, List<GetAllColumnsResponse>>
{
    public GetAllColumnsHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<List<GetAllColumnsResponse>> Handle(GetAllColumnsRequest request, CancellationToken cancellationToken)
    {
        List<Column> columns = await getter.GenericRepository<Column>().GetAllAsync(predicate: b => !b.IsDeleted);
        var res = columns.Select(mapper.Map<Column, GetAllColumnsResponse>).ToList();

        return res;

    }
}
