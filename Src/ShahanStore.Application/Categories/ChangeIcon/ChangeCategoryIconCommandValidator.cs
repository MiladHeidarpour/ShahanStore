using Common.Application.Validations;
using FluentValidation;

namespace ShahanStore.Application.Categories.ChangeIcon;

public class ChangeCategoryIconCommandValidator : AbstractValidator<ChangeCategoryIconCommand>
{
    public ChangeCategoryIconCommandValidator()
    {
        RuleFor(r => r.Icon)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("آیکون"));
    }
}