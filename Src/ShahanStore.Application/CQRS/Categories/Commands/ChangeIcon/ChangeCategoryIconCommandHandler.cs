using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Commands.ChangeIcon;

internal sealed class ChangeCategoryIconCommandHandler(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork) : ICommandHandler<ChangeCategoryIconCommand,string?>
{
    public async Task<OperationResult<string?>> Handle(ChangeCategoryIconCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.FindByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            return OperationResult<string?>.NotFound();
        }

        string? oldIconImage=category.Icon;
        category.ChangeIcon(request.Icon);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult<string?>.Success(oldIconImage);
    }
}