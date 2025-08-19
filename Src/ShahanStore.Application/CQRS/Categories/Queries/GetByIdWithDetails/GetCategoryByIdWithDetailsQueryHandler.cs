using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetByIdWithDetails;

internal class GetCategoryByIdWithDetailsQueryHandler(ICategoryRepository categoryRepository)
    : IQueryHandler<GetCategoryByIdWithDetailsQuery, CategoryDto?>
{
    public async Task<CategoryDto?> Handle(GetCategoryByIdWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdWithDetailsAsync(request.CategoryId,cancellationToken);
        return category.Map();
    }
}