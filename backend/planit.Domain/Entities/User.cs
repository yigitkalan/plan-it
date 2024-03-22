using planit.Domain.Base;

namespace planit.Domain.Entities;
public class User: Entity
{

    public ICollection<Board> ParticipatedBoards { get; set; }= new List<Board>();
    public ICollection<Item> Tasks { get; set; } = new List<Item>();

}
