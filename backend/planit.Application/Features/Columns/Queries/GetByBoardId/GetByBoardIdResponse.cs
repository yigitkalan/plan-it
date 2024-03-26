using planit.Application.DTOs;

namespace planit.Application.Features;
public class GetByBoardIdResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BoardId { get; set; }

    public List<ItemDto> Tasks { get; set; }
}
