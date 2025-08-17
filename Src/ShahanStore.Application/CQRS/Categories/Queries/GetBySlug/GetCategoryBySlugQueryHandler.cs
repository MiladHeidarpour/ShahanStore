using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetBySlug;

internal sealed class GetCategoryBySlugQueryHandler(ICategoryRepository categoryRepository)
    : IQueryHandler<GetCategoryBySlugQuery, CategoryDto?>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<CategoryDto?> Handle(GetCategoryBySlugQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetBySlugAsync(request.Slug, cancellationToken);
        return category.Map();
    }
}
