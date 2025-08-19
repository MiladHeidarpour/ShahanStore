using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using ShahanStore.Domain.Brands;

namespace ShahanStore.Application.CQRS.Brands.Commands.ChangeLogo;

internal sealed class ChangeBrandLogoCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<ChangeBrandLogoCommand, string?>
{
    public async Task<OperationResult<string?>> Handle(ChangeBrandLogoCommand request, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.FindByIdAsync(request.BrandId, cancellationToken);

        if (brand is null) return OperationResult<string?>.NotFound();

        var oldIconImage = brand.Logo;
        brand.ChangeLogo(request.Logo);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult<string?>.Success(oldIconImage);
    }
}
