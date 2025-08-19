using Common.Application.Validations;
using FluentValidation;

namespace ShahanStore.Application.CQRS.Brands.Commands.ChangeBanner;

public sealed class ChangeBrandBannerCommandValidator : AbstractValidator<ChangeBrandBannerCommand>
{
    public ChangeBrandBannerCommandValidator()
    {
        RuleFor(r => r.BannerImg)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.Required("تصویر"));
    }
}
