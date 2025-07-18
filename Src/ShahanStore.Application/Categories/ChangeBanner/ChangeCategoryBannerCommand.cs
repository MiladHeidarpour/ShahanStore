using Common.Application.Abstractions.Messaging.Commands;
using ShahanStore.Application.Categories.AddChild;

namespace ShahanStore.Application.Categories.ChangeBanner;

public sealed record ChangeCategoryBannerCommand(
    Guid CategoryId,
    string BannerImg) : ICommand;