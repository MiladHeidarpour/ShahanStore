using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using Common.Domain.Utilities;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Commands.Edit;

internal sealed class EditCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : ICommandHandler<EditCategoryCommand>
{
    public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.FindByIdAsync(request.Id, cancellationToken);
        if (category is null)
        {
            return OperationResult.NotFound();
        }

        string newSlug = request.Slug.ToSlug();
        if (category.Slug != newSlug)
        {
            if (await categoryRepository.IsSlugDuplicateAsync(request.Slug.ToSlug(), cancellationToken))
            {
                return OperationResult.Error("اسلاگ وارد شده تکراری است.");
            }
        }

        category.Edit(request.Title, newSlug, request.SeoData);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult.Success();
    }
}