using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Commands.ChangeBanner;

internal class ChangeCategoryBannerCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<ChangeCategoryBannerCommand>
{
    public async Task<OperationResult> Handle(ChangeCategoryBannerCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.CategoryId);

        if (category is null)
        {
            return OperationResult.NotFound();
        }

        category.ChangeBanner(request.BannerImg);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult.Success();
    }
}