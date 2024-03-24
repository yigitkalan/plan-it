using FluentValidation;

namespace planit.Application.Features;
public class LogoutValidator: AbstractValidator<LogoutRequest>
{
    public LogoutValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotEmpty();
        
    }

}
