using FluentValidation;

namespace planit.Application.Features;
public class RevokeValidator: AbstractValidator<LogoutRequest>
{
    public RevokeValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotEmpty();
        
    }

}
