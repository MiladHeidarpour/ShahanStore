using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Commands.ChangeBanner;

internal sealed class ChangeCategoryBannerCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<ChangeCategoryBannerCommand, string?>
{
    public async Task<OperationResult<string?>> Handle(ChangeCategoryBannerCommand request,
        CancellationToken cancellationToken)
    {
        var category = await categoryRepository.FindByIdAsync(request.CategoryId, cancellationToken);

        if (category is null) return OperationResult<string?>.NotFound();

        var oldBannerImage = category.BannerImg;
        category.ChangeBanner(request.BannerImg);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult<string?>.Success(oldBannerImage);
    }
}