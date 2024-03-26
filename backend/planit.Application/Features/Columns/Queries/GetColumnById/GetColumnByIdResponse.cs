using planit.Application.DTOs;

namespace planit.Application.Features;
public class GetColumnByIdResponse
{
    public ColumnDto Column { get; set; }
    public ICollection<ItemDto> Tasks { get; set; } = new List<ItemDto>();

}
