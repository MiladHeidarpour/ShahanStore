using Common.Application.Abstractions.Messaging.Queries;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Application.CQRS.Products.DTOs.Queries;

namespace ShahanStore.Application.CQRS.Products.Queries.GetByFilter;

internal sealed class GetProductByFilterQueryHandler(IApplicationDbContext context, IMapper mapper) 
    : IQueryHandler<GetProductByFilterQuery, ProductFilterResult>
{
    public async Task<ProductFilterResult> Handle(GetProductByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = context.Products.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.FilterParams.Search))
        {
            var searchTerm = request.FilterParams.Search.Trim();
            query = query.Where(c =>
                    c.FaName.Contains(searchTerm) ||
                    c.EnName.Contains(searchTerm) ||
                    c.Slug.Contains(searchTerm) ||
                    c.ProductCode.Contains(searchTerm)
            );
        }

        if (request.FilterParams.Status != null)
            query = request.FilterParams.Status switch
            {
                Status.Active => query.Where(f => f.IsAvailable == true),
                Status.NotActive => query.Where(f => f.IsAvailable == false),
                _ => query
            };

        var result = new ProductFilterResult();

        var count = await query.CountAsync(cancellationToken);
        result.GeneratePaging(count, request.FilterParams.Take, request.FilterParams.PageId);

        var skip = (request.FilterParams.PageId - 1) * request.FilterParams.Take;
        var pagedQuery = query.OrderByDescending(c => c.CreationDate).Skip(skip).Take(request.FilterParams.Take);


        result.Data = await pagedQuery
            .ProjectToType<ProductFilterData>(mapper.Config)
            .ToListAsync(cancellationToken);

        return result;
    }
}