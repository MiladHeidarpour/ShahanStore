using Common.Application.Abstractions.Messaging.Queries;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetByFilter;

internal sealed class GetCategoriesByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IQueryHandler<GetCategoriesByFilterQuery, CategoryFilterResult>
{
    public async Task<CategoryFilterResult> Handle(GetCategoriesByFilterQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.Categories.Where(f=>f.ParentId==null).AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.FilterParams.Search))
        {
            var searchTerm = request.FilterParams.Search.Trim();
            query = query.Where(c =>
                    c.Title.Contains(searchTerm) ||
                    c.Slug.Contains(searchTerm) ||
                    c.Id.Equals(searchTerm) 
            );
        }

        if (request.FilterParams.Status != null)
            query = request.FilterParams.Status switch
            {
                Status.Active => query.Where(f => f.IsDeleted == false),
                Status.NotActive => query.Where(f => f.IsDeleted == true),
                _ => query
            };

        var result = new CategoryFilterResult();

        var count = await query.CountAsync(cancellationToken);
        result.GeneratePaging(count, request.FilterParams.Take, request.FilterParams.PageId);

        var skip = (request.FilterParams.PageId - 1) * request.FilterParams.Take;
        var pagedQuery = query.OrderByDescending(c => c.CreationDate).Skip(skip).Take(request.FilterParams.Take);


        result.Data = await pagedQuery
            .ProjectToType<CategoryFilterData>(mapper.Config)
            .ToListAsync(cancellationToken);

        return result;
    }
}