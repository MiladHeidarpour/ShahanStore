using Common.Application.Validations;
using FluentValidation;

namespace ShahanStore.Application.CQRS.Brands.Commands.Create;

public sealed class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("عنوان"));

        RuleFor(r => r.Slug)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("اسلاگ"));
    }
}