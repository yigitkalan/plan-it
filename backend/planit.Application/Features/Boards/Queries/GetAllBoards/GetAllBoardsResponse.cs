using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetAllBoardsResponse
{
    public string Name { get; set; }
    public Guid OwnerId { get; set; }
    public List<User> Users { get; set; }
}
