using planit.Application.DTOs;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class GetByBoardIdResponse
{
    public ICollection<ColumnDto> Columns { get; set; } = new List<ColumnDto>();
}
