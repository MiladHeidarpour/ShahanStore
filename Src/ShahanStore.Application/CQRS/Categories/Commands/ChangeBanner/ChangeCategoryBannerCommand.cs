using Common.Application.Abstractions.Messaging.Commands;

namespace ShahanStore.Application.CQRS.Categories.Commands.ChangeBanner;

public sealed record ChangeCategoryBannerCommand(
    Guid CategoryId,
    string BannerImg) : ICommand;