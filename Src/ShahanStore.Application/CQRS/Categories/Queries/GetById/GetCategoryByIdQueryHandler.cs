using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Categories._Dtos.Queries;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetById;

internal class GetCategoryByIdQueryHandler(ICategoryRepository repository) : IQueryHandler<GetCategoryByIdQuery, CategoryDto?>
{
    public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category=await repository.GetByIdAsync(request.CategoryId);
        return category.Map();
    }
}