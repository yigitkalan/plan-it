using MediatR;

namespace planit.Application.Features;
public class GetUserByIdRequest: IRequest<GetUserByIdResponse>
{
    public string Id { get; set; }

}
