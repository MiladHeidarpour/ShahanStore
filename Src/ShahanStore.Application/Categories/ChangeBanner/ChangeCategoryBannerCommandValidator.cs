using Common.Application.Validations;
using FluentValidation;

namespace ShahanStore.Application.Categories.ChangeBanner;

public class ChangeCategoryBannerCommandValidator : AbstractValidator<ChangeCategoryBannerCommand>
{
    public ChangeCategoryBannerCommandValidator()
    {
        RuleFor(r => r.BannerImg)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("تصویر"));
    }
}