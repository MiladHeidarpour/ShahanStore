using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Products.DTOs.Queries;
using ShahanStore.Domain.Products;

namespace ShahanStore.Application.CQRS.Products.Queries.GetById;

internal sealed class GetProductByIdQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductByIdQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId,cancellationToken);
        return product.Map();
    }
}   
