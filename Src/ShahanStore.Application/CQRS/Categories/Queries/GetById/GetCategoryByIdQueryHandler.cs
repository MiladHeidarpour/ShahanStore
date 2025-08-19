using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetById;

internal sealed class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
    : IQueryHandler<GetCategoryByIdQuery, CategoryDto?>
{
    public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
        return category.Map();
    }
}