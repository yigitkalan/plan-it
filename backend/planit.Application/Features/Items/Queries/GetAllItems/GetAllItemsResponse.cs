using planit.Application.DTOs;

namespace planit.Application.Features;
public class GetAllItemsResponse
{
    public ICollection<ItemDto> Items { get; set; } = new List<ItemDto>();

}
