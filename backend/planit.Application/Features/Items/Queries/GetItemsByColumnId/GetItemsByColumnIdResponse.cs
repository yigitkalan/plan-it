using planit.Application.DTOs;

namespace planit.Application.Features;
public class GetItemsByColumnIdResponse
{
    public ICollection<ItemDto> Items { get; set; }

}
