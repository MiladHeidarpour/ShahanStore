using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Categories._Dtos.Queries;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetById;

internal sealed class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository) : IQueryHandler<GetCategoryByIdQuery, CategoryDto?>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category=await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
        return category.Map();
    }
}