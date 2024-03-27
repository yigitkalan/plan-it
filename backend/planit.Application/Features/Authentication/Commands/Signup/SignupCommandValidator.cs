using FluentValidation;

namespace planit.Application.Features;
public class SignupCommandValidator: AbstractValidator<SignupRequest>
{
    public SignupCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(60).MinimumLength(8).EmailAddress();
        RuleFor(x => x.Username).NotEmpty().MaximumLength(20).MinimumLength(4);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}
