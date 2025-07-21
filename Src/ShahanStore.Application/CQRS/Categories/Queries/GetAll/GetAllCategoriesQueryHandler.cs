using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Categories._Dtos.Queries;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetAll;

internal class GetAllCategoriesQueryHandler(ICategoryRepository repository) : IQueryHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await repository.GetAllAsync();
        return categories.Map();
    }
}