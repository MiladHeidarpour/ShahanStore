using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetAll;

public sealed record GetAllCategoriesQuery : IQuery<List<CategoryDto>>;