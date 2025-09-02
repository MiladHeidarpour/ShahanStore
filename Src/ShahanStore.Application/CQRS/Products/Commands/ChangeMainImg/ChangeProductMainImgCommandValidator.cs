using Common.Application.Validations;
using FluentValidation;

namespace ShahanStore.Application.CQRS.Products.Commands.ChangeMainImg;

public class ChangeProductMainImgCommandValidator:AbstractValidator<ChangeProductMainImgCommand>
{
    public ChangeProductMainImgCommandValidator()
    {
        RuleFor(p => p.ProductId)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("شناسه محصول"));

        RuleFor(r => r.MainImg)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("تصویر"));
    }
}
