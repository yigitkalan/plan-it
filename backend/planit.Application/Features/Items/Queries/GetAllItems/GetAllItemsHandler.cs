using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetAllItemsHandler : BaseHandler, IRequestHandler<GetAllItemsRequest, GetAllItemsResponse>
{
    public GetAllItemsHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<GetAllItemsResponse> Handle(GetAllItemsRequest request, CancellationToken cancellationToken)
    {
        var items = await getter.GenericRepository<Item>().GetAllAsync(predicate: i => i.IsDeleted == false, orderBy: q => q.OrderBy(i => i.Order));

        return new GetAllItemsResponse
        {
            Items = items.Select(i => mapper.Map<Item, ItemDto>(i)).ToList()
        };
    }
}
