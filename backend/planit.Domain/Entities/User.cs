using planit.Domain.Base;

namespace planit.Domain.Entities;
public class User: Entity
{

    public ICollection<Board> ParticipatedBoards { get; set; }
    public ICollection<Board> OwnedBoards { get; set; }

}
