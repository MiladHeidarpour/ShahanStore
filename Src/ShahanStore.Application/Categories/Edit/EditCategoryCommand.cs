using Common.Application.Abstractions.Messaging.Commands;
using Common.Domain.ValueObjects;
using ShahanStore.Application.Categories.Create;

namespace ShahanStore.Application.Categories.Edit;

public sealed record EditCategoryCommand(
    Guid Id,
    string Title,
    string Slug,
    SeoData SeoData) : ICommand;