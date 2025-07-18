using Common.Application.Abstractions.Messaging.Commands;
using Common.Domain.ValueObjects;
using ShahanStore.Application.Categories.Create;

namespace ShahanStore.Application.Categories.AddChild;

public sealed record AddChildCategoryCommand(string Title,
    string Slug,
    Guid ParentId,
    string? BannerImg,
    string? Icon,
    SeoData SeoData):ICommand;