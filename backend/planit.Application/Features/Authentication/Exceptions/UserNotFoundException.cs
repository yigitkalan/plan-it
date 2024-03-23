using planit.Application.Bases;

namespace planit.Application.Exceptions;
public class UserNotFoundException: BaseException
{
    public UserNotFoundException(): base("No user found with the email") { }

}
