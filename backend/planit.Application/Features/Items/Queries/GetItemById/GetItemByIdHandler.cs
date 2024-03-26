using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetItemByIdHandler : BaseHandler, IRequestHandler<GetItemByIdRequest, GetItemByIdResponse>
{
    public GetItemByIdHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<GetItemByIdResponse> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
    {
        var item = await getter.GenericRepository<Item>().GetAsync(i => i.Id == request.ItemId && i.IsDeleted == false);
        return new GetItemByIdResponse
        {
            Item = mapper.Map<Item, ItemDto>(item)
        };

    }
}
