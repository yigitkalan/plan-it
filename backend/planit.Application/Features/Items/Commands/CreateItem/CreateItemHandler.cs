using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class CreateItemHandler : BaseHandler, IRequestHandler<CreateItemRequest, CreateItemResponse>
{
    public CreateItemHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<CreateItemResponse> Handle(CreateItemRequest request, CancellationToken cancellationToken)
    {
        var column = await getter.GenericRepository<Column>().GetAsync(c => c.Id == request.ColumnId && c.IsDeleted == false) ?? throw new Exception("Column not found");
        //CHECK IF WHEN ADD ITEMS IT ADDS TO COLUMNS ITEMS LIST

        Item item = mapper.Map<CreateItemRequest, Item>(request);
        await getter.GenericRepository<Item>().AddAsync(item);

        return new CreateItemResponse
        {
            Item = mapper.Map<Item, ItemDto>(item)
        };
    }
}
