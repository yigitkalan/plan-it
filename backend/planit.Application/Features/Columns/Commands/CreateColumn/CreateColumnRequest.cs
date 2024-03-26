using MediatR;
namespace planit.Application.Features;
public class CreateColumnRequest: IRequest<CreateColumnResponse>
{
    public string Name { get; set; }
    public int Order { get; set; }
    public Guid BoardId { get; set; }

}
