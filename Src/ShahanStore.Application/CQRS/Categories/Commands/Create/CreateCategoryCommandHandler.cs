using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using Common.Domain.Utilities;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Commands.Create;

internal sealed class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand>
{
    public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (await categoryRepository.IsSlugDuplicateAsync(request.Slug.ToSlug(), cancellationToken))
        {
            return OperationResult.Error("اسلاگ وارد شده تکراری است.");
        }

        Category category=Category.CreateNew(request.Title, request.Slug, null, request.BannerImg, request.Icon,
            request.SeoData);

        categoryRepository.Add(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult.Success();
    }
}