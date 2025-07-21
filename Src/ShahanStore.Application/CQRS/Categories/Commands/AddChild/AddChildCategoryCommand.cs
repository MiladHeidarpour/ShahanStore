using Common.Application.Abstractions.Messaging.Commands;
using Common.Domain.ValueObjects;

namespace ShahanStore.Application.CQRS.Categories.Commands.AddChild;

public sealed record AddChildCategoryCommand(string Title,
    string Slug,
    Guid ParentId,
    string? BannerImg,
    string? Icon,
    SeoData SeoData):ICommand;