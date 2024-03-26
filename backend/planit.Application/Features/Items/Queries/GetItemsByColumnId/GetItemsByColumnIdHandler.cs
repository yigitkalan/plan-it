using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetItemsByColumnIdHandler : BaseHandler, IRequestHandler<GetItemsByColumnIdRequest, GetItemsByColumnIdResponse>
{
    public GetItemsByColumnIdHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<GetItemsByColumnIdResponse> Handle(GetItemsByColumnIdRequest request, CancellationToken cancellationToken)
    {
        List<Item> items = await getter.GenericRepository<Item>().GetAllAsync(i => i.ColumnId == request.ColumnId && i.IsDeleted == false);

        return new GetItemsByColumnIdResponse
        {
            Items = items.Select(i => mapper.Map<Item, ItemDto>(i)).ToList()
        };
    }
}
