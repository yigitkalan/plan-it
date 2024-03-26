using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetByBoardIdResponse
{
    public ICollection<Column> Columns { get; set; }= new List<Column>();
}
