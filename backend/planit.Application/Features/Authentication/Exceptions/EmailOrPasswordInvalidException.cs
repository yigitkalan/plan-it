using planit.Application.Bases;

namespace planit.Application.Exceptions;
public class EmailOrPasswordInvalidException: BaseException
{
    public EmailOrPasswordInvalidException(): base("Email or password is invalid") {
    }

}
