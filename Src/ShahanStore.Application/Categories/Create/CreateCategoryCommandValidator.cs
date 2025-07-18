using Common.Application.Validations;
using FluentValidation;

namespace ShahanStore.Application.Categories.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("عنوان"));

        RuleFor(r => r.Slug)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("اسلاگ"));
    }
}