using Common.Application.Abstractions.Messaging.Commands;
using Common.Domain.ValueObjects;

namespace ShahanStore.Application.CQRS.Categories.Commands.Edit;

public sealed record EditCategoryCommand(
    Guid Id,
    string Title,
    string Slug,
    SeoData SeoData) : ICommand;