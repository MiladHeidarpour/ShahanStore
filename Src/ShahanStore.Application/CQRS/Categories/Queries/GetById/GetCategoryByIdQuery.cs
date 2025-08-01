using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetById;

public sealed record GetCategoryByIdQuery(Guid CategoryId) : IQuery<CategoryDto?>;