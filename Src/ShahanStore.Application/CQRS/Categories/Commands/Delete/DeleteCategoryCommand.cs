using Common.Application.Abstractions.Messaging.Commands;

namespace ShahanStore.Application.CQRS.Categories.Commands.Delete;

public sealed record DeleteCategoryCommand(Guid CategoryId) : ICommand;