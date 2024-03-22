using planit.Domain.Base;

namespace planit.Domain.Entities;
public class User: Entity
{

    public ICollection<Board> Boards { get; set; }

}
