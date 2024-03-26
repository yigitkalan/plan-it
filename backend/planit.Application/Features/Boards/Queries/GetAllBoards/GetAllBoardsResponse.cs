using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetAllBoardsResponse
{
    public ICollection<BoardDto> Boards {get; set;} = new List<BoardDto>();
}
