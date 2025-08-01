using Common.Application.Abstractions.Messaging.Queries;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetByFilter;

public sealed record GetCategoriesByFilterQuery(CategoryFilterParams FilterParams) : IQuery<CategoryFilterResult>;

internal sealed class GetCategoriesByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IQueryHandler<GetCategoriesByFilterQuery, CategoryFilterResult>
{
    public async Task<CategoryFilterResult> Handle(GetCategoriesByFilterQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.Categories.AsNoTracking().AsQueryable();

        if (request.FilterParams.CategoryId is not null)
            query = query.Where(f => f.Id == request.FilterParams.CategoryId);
        if (!string.IsNullOrWhiteSpace(request.FilterParams.Slug))
            query = query.Where(f => f.Slug == request.FilterParams.Slug);
        if (!string.IsNullOrWhiteSpace(request.FilterParams.Search))
            query = query.Where(c =>
                c.Title.Contains(request.FilterParams.Search) || c.Slug.Contains(request.FilterParams.Search));

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


        result.Categories = await pagedQuery
            .ProjectToType<CategoryDto>(mapper.Config)
            .ToListAsync(cancellationToken);

        return result;
    }
}