using planit.Application.DTOs;

namespace planit.Application.Features;
public class GetBoardsByUserIdResponse
{
    public ICollection<BoardDto> Boards { get; set; } = new List<BoardDto>();

}
