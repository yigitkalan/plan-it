namespace planit.Application.DTOs;
public class ItemDto
{

    public Guid Id { get; set; }
    public int Order { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ColumnId { get; set; }

}
