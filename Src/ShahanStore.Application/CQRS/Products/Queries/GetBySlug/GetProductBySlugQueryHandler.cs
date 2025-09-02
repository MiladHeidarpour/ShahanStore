using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Products.DTOs.Queries;
using ShahanStore.Domain.Products;

namespace ShahanStore.Application.CQRS.Products.Queries.GetBySlug;

internal sealed class GetProductBySlugQueryHandler(IProductRepository productRepository):IQueryHandler<GetProductBySlugQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
    {
        var product=await productRepository.GetBySlugAsync(request.Slug,cancellationToken);
        return product.Map();
    }
}
