using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class DeleteItemHandler : BaseHandler, IRequestHandler<DeleteItemRequest, Unit>
{
    public DeleteItemHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<Unit> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
    {
        var item = await getter.GenericRepository<Item>()
        .GetAsync(i => i.Id == request.ItemId && i.IsDeleted == false, enableTracking: true)
         ?? throw new Exception("Item not found");

        item.IsDeleted = true;
        await getter.GenericRepository<Item>().UpdateAsync(item);

        return Unit.Value; 
    }
}
