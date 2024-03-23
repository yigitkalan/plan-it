using FluentValidation;

namespace planit.Application.Features;
public class CreateBoardValidator: AbstractValidator<CreateBoardRequest>
{
    public CreateBoardValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
        RuleFor(x => x.OwnerId).GreaterThan(0);
    }
}