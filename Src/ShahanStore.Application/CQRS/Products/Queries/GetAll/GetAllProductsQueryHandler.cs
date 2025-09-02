using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Products.DTOs.Queries;
using ShahanStore.Domain.Products;

namespace ShahanStore.Application.CQRS.Products.Queries.GetAll;

internal sealed class GetAllProductsQueryHandler(IProductRepository productRepository)
    : IQueryHandler<GetAllProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var query = await productRepository.GetAllAsync(cancellationToken);
        return query.Map();
    }
}
