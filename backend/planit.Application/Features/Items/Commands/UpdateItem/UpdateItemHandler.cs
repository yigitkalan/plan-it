using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class UpdateItemHandler : BaseHandler, IRequestHandler<UpdateItemRequest, UpdateItemResponse>
{
    public UpdateItemHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<UpdateItemResponse> Handle(UpdateItemRequest request, CancellationToken cancellationToken)
    {
        var item = await getter.GenericRepository<Item>()
        .GetAsync(i => i.Id == request.Id && i.IsDeleted == false, enableTracking: true)
        ?? throw new Exception("Item not found");

        item.Title = request.Title;
        item.Description = request.Description;
        item.Order = request.Order;
        item.ColumnId = request.ColumnId;

        await getter.GenericRepository<Item>().UpdateAsync(item);

        return new UpdateItemResponse
        {
            Item = mapper.Map<Item, ItemDto>(item)
        };
    }
}
