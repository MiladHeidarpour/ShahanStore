using Common.Application.Abstractions.Messaging.Commands;

namespace ShahanStore.Application.CQRS.Categories.Commands.ChangeIcon;

public sealed record ChangeCategoryIconCommand(
    Guid CategoryId,
    string Icon) : ICommand<string?>;