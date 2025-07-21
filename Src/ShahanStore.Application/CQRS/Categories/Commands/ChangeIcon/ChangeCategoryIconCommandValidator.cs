using Common.Application.Validations;
using FluentValidation;

namespace ShahanStore.Application.CQRS.Categories.Commands.ChangeIcon;

public sealed class ChangeCategoryIconCommandValidator : AbstractValidator<ChangeCategoryIconCommand>
{
    public ChangeCategoryIconCommandValidator()
    {
        RuleFor(r => r.Icon)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("آیکون"));
    }
}