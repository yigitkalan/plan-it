using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetByBoardIdHandler : BaseHandler, IRequestHandler<GetByBoardIdRequest, List<GetByBoardIdResponse>>
{
    public GetByBoardIdHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<List<GetByBoardIdResponse>> Handle(GetByBoardIdRequest request, CancellationToken cancellationToken)
    {
        List<Column> columns = await getter.GenericRepository<Column>().GetAllAsync(b => b.BoardId == request.BoardId && !b.IsDeleted);

        List<GetByBoardIdResponse> response =  columns.Select(mapper.Map<Column, GetByBoardIdResponse>).ToList();
        return response;
    }
}
