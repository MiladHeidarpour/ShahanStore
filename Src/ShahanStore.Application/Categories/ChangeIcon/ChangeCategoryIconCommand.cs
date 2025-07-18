using Common.Application.Abstractions.Messaging.Commands;
using ShahanStore.Application.Categories.ChangeBanner;

namespace ShahanStore.Application.Categories.ChangeIcon;

public sealed record ChangeCategoryIconCommand(
    Guid CategoryId,
    string Icon) : ICommand;