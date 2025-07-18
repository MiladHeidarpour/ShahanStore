
using Common.Application.Abstractions.Messaging.Commands;
using Common.Domain.ValueObjects;

namespace ShahanStore.Application.Categories.Create;

public sealed record CreateCategoryCommand(
    string Title,
    string Slug,
    string? BannerImg,
    string? Icon,
    SeoData SeoData) : ICommand;