using planit.Domain.Base;

namespace planit.Domain.Entities;
public class Column: Entity
{
    public string Name { get; set; }
    public int Order { get; set; }
    public Guid BoardId { get; set; }
    public Board Board { get; set; }
    public ICollection<Item> Tasks { get; set; }


    public Column()
    {
    }

    public Column(string name, Guid boardId)
    {
        Name = name;
        BoardId = boardId;
    }
}
