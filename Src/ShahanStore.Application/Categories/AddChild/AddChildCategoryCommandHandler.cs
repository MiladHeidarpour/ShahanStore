using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using Common.Domain.Utilities;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.Categories.AddChild;

internal class AddChildCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<AddChildCategoryCommand>
{
    public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
    {
        var parentCategory = await categoryRepository.GetByIdAsync(request.ParentId);
        if (parentCategory is null)
        {
            return OperationResult.NotFound();
        }

        if (await categoryRepository.IsSlugDuplicateAsync(request.Slug.ToSlug()))
        {
            return OperationResult.Error("اسلاگ وارد شده تکراری است.");
        }

        var childCategory = new Category(request.Title, request.Slug, request.ParentId, request.BannerImg, request.Icon,
            request.SeoData);

        categoryRepository.Add(childCategory);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult.Success();
    }
}