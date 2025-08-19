using Common.Application.Validations;
using FluentValidation;

namespace ShahanStore.Application.CQRS.Brands.Commands.ChangeLogo;

public sealed class ChangeBrandLogoCommandValidator : AbstractValidator<ChangeBrandLogoCommand>
{
    public ChangeBrandLogoCommandValidator()
    {
        RuleFor(r => r.Logo)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("لوگو"));
    }
}
