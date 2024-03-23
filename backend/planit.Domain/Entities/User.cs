using Microsoft.AspNetCore.Identity;
using planit.Domain.Base;

namespace planit.Domain.Entities;
public class User: IdentityUser<Guid>, IEntity
{

    public ICollection<Board> ParticipatedBoards { get; set; }= new List<Board>();
    public ICollection<Item> Tasks { get; set; } = new List<Item>();

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiration { get; set; }

}
