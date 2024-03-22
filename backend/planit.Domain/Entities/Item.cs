using planit.Domain.Base;

namespace planit.Domain.Entities;
public class Item: Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ColumnId { get; set; }
    public Column Column { get; set; }
    
    public ICollection<User> AssignedUsers { get; set; } = new List<User>();

    public Item()
    {
    }

    public Item(string title, string description, int columnId)
    {
        Title = title;
        Description = description;
        ColumnId = columnId;
    }

}
