using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using Common.Domain.Utilities;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Commands.AddChild;

internal sealed class AddChildCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<AddChildCategoryCommand>
{
    public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
    {
        var parentCategory = await categoryRepository.GetByIdAsync(request.ParentId,cancellationToken);
        if (parentCategory is null)
        {
            return OperationResult.NotFound();
        }

        if (await categoryRepository.IsSlugDuplicateAsync(request.Slug.ToSlug(),cancellationToken))
        {
            return OperationResult.Error("اسلاگ وارد شده تکراری است.");
        }

        var childCategory = Category.CreateNew(request.Title, request.Slug, request.ParentId, request.BannerImg, request.Icon,
            request.SeoData);

        categoryRepository.Add(childCategory);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult.Success();
    }
}