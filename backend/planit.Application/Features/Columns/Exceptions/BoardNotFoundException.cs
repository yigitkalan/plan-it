using planit.Application.Bases;

namespace planit.Application.Features;
public class BoardNotFoundException: BaseException
{
    public BoardNotFoundException(): base("Board not found"){}

}
