using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Products.DTOs.Queries;
using ShahanStore.Domain.Products;

namespace ShahanStore.Application.CQRS.Products.Queries.GetByProductCode;

internal sealed class GetProductByCodeQueryHandler(IProductRepository productRepository):IQueryHandler<GetProductByCodeQuery,ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByCodeQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByCodeAsync(request.ProductCode, cancellationToken);
        return product.Map();
    }
}
