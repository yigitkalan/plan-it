using planit.Domain.Base;

namespace planit.Domain.Entities;
public class Column: Entity
{
    public string Name { get; set; }
    public int BoardId { get; set; }
    public Board Board { get; set; }
    public ICollection<Item> Tasks { get; set; }

}
