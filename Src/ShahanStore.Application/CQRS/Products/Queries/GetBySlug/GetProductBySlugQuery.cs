using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Products.DTOs.Queries;

namespace ShahanStore.Application.CQRS.Products.Queries.GetBySlug;
public sealed record GetProductBySlugQuery(string Slug):IQuery<ProductDto?>;
