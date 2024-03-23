using planit.Application.Bases;

namespace planit.Application.Features;
public class UserAlreadyExistException: BaseException
{
    public UserAlreadyExistException(): base("User already exist!") { }

}
