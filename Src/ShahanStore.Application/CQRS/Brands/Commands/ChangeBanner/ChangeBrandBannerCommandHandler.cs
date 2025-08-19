using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using ShahanStore.Domain.Brands;

namespace ShahanStore.Application.CQRS.Brands.Commands.ChangeBanner;

internal sealed class ChangeBrandBannerCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<ChangeBrandBannerCommand, string?>
{
    public async Task<OperationResult<string?>> Handle(ChangeBrandBannerCommand request, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.FindByIdAsync(request.BrandId, cancellationToken);

        if (brand is null) return OperationResult<string?>.NotFound();

        var oldBannerImage = brand.BannerImg;
        brand.ChangeBanner(request.BannerImg);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult<string?>.Success(oldBannerImage);
    }
}
