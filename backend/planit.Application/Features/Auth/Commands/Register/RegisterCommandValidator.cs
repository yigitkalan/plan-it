using System.Data;
using FluentValidation;

namespace planit.Application.Features;
public class RegisterCommandValidator: AbstractValidator<RegisterRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(60).MinimumLength(8).EmailAddress();
        RuleFor(x => x.Username).NotEmpty().MaximumLength(20).MinimumLength(4);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        RuleFor(x => x.ConfirmPassword).NotEmpty().MinimumLength(6).Equal(x => x.Password);
    }
}
