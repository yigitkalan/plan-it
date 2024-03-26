using planit.Application.DTOs;

namespace planit.Application.Features;
public class GetAllColumnsResponse
{
    public ICollection<ColumnDto> Columns { get; set; }= new List<ColumnDto>();
}
