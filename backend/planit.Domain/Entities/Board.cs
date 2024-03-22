using planit.Domain.Base;

namespace planit.Domain.Entities;
public class Board: Entity
{
    public string Name { get; set; }
    public int OwnerId { get; set; }
    // public User Owner { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Column> Columns { get; set; } = new List<Column>();

    public Board()
    {
    }

    public Board(string name, int ownerId)
    {
        Name = name;
        OwnerId = ownerId;
    }

}
