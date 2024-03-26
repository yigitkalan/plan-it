using planit.Application.DTOs;

namespace planit.Application.Features;
public class GetBoardByIdResponse
{
    public BoardDto board { get; set; }
    public List<ColumnDto> Columns { get; set; }

}
