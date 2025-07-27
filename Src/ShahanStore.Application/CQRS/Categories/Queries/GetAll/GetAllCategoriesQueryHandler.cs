using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetAll;

internal sealed class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository) : IQueryHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync(cancellationToken);
        return categories.Map();
    }
}