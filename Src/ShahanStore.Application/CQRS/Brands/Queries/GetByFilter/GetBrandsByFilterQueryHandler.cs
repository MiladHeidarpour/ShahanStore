using Common.Application.Abstractions.Messaging.Queries;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ShahanStore.Application.CQRS.Brands.DTOs.Queries;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;

namespace ShahanStore.Application.CQRS.Brands.Queries.GetByFilter;

internal sealed class GetBrandsByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IQueryHandler<GetBrandsByFilterQuery, BrandFilterResult>
{
    public async Task<BrandFilterResult> Handle(GetBrandsByFilterQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.Brands.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.FilterParams.Search))
        {
            var searchTerm = request.FilterParams.Search.Trim();
            query = query.Where(c =>
                    c.Name.Contains(searchTerm) ||
                    c.Slug.Contains(searchTerm) ||
                    c.Description.Contains(searchTerm) ||
                    c.Id.Equals(searchTerm)
            );
        }

        if (request.FilterParams.Status != null)
            query = request.FilterParams.Status switch
            {
                Status.Active => query.Where(f => f.IsAvailable == true),
                Status.NotActive => query.Where(f => f.IsAvailable == false),
                _ => query
            };

        var result = new BrandFilterResult();

        var count = await query.CountAsync(cancellationToken);
        result.GeneratePaging(count, request.FilterParams.Take, request.FilterParams.PageId);

        var skip = (request.FilterParams.PageId - 1) * request.FilterParams.Take;
        var pagedQuery = query.OrderByDescending(c => c.CreationDate).Skip(skip).Take(request.FilterParams.Take);


        result.Data = await pagedQuery
            .ProjectToType<BrandFilterData>(mapper.Config)
            .ToListAsync(cancellationToken);

        return result;
    }
}