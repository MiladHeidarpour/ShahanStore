using Common.Application.Validations;
using FluentValidation;

namespace ShahanStore.Application.CQRS.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.FaName)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.Required("نام محصول(فارسی)"));

        RuleFor(x => x.EnName)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.Required("نام محصول(انگلیسی)"));

        RuleFor(x => x.Slug)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.Required("اسلاگ"));

        RuleFor(x => x.ProductCode)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.Required("کد محصول"));

        RuleFor(r => r.MainImg)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.Required("تصویر"));

        RuleFor(x => x.CategoryId)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.Required("دسته‌بندی"));

        RuleFor(x => x.BrandId)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.Required("برند"));
    }
}
