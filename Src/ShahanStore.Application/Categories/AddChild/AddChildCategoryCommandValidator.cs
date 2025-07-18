using Common.Application.Validations;
using FluentValidation;

namespace ShahanStore.Application.Categories.AddChild;

public class AddChildCategoryCommandValidator : AbstractValidator<AddChildCategoryCommand>
{
    public AddChildCategoryCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("عنوان"));

        RuleFor(r => r.Slug)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("اسلاگ"));
    }
}