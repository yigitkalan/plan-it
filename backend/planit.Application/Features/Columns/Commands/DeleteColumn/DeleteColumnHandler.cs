using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class DeleteColumnHandler : BaseHandler, IRequestHandler<DeleteColumnRequest, Unit>
{
    public DeleteColumnHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<Unit> Handle(DeleteColumnRequest request, CancellationToken cancellationToken)
    {
        var column = await getter.GenericRepository<Column>().GetAsync(predicate: c => c.Id == request.ColumnId && !c.IsDeleted)
            ?? throw new Exception("Column not found");
        column.IsDeleted = true;
        await getter.GenericRepository<Column>().UpdateAsync(column);
        return Unit.Value;
    }
}
