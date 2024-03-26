using MediatR;

namespace planit.Application.Features;
public class GetAllColumnsRequest: IRequest<List<GetAllColumnsResponse>>
{
}
