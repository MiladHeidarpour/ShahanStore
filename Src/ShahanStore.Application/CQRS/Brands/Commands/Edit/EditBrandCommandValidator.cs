using Common.Application.Validations;
using FluentValidation;

namespace ShahanStore.Application.CQRS.Brands.Commands.Edit;

public sealed class EditBrandCommandValidator : AbstractValidator<EditBrandCommand>
{
    public EditBrandCommandValidator()
    {
        RuleFor(r => r.Name)
           .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("عنوان"));

        RuleFor(r => r.Slug)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("اسلاگ"));
    }
}
