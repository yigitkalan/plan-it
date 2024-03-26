using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using planit.Application.Abstractions;
using planit.Application.Bases;
using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetBoardsByUserIdHandler : BaseHandler, IRequestHandler<GetBoardsByUserIdRequest, GetBoardsByUserIdResponse>
{

    public GetBoardsByUserIdHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor) : base(mapper, getter, httpContextAccessor)
    {
    }

    public async Task<GetBoardsByUserIdResponse> Handle(GetBoardsByUserIdRequest request, CancellationToken cancellationToken)
    {
        var boards = await getter.GenericRepository<Board>().GetAllAsync(predicate: b => !b.IsDeleted && b.Users.Any(u => u.Id == request.UserId));

        var response = new GetBoardsByUserIdResponse
        {
            Boards = boards.Select(board => mapper.Map<Board, BoardDto>(board)).ToList()
        };

        return response;
    }
}
