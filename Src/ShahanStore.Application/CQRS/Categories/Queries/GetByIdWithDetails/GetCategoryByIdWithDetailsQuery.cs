using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetByIdWithDetails;

public sealed record GetCategoryByIdWithDetailsQuery(Guid CategoryId) : IQuery<CategoryDto?>;


internal class GetCategoryByIdWithDetailsQueryHandler(ICategoryRepository categoryRepository)
    : IQueryHandler<GetCategoryByIdWithDetailsQuery, CategoryDto?>
{
    public async Task<CategoryDto?> Handle(GetCategoryByIdWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdWithDetailsAsync(request.CategoryId,cancellationToken);
        return category.Map();
    }
}