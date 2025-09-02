using Common.Application.Validations;
using FluentValidation;

namespace ShahanStore.Application.CQRS.Products.Commands.Edit;

public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
{
    public EditProductCommandValidator()
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


        RuleFor(x => x.CategoryId)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.Required("دسته‌بندی"));

        RuleFor(x => x.BrandId)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.Required("برند"));

        RuleFor(x => x.IsAvailable)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.Required("موجود است"));
    }
}