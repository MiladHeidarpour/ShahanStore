using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Products.DTOs.Queries;

namespace ShahanStore.Application.CQRS.Products.Queries.GetAll;
public sealed record GetAllProductsQuery : IQuery<List<ProductDto>>;