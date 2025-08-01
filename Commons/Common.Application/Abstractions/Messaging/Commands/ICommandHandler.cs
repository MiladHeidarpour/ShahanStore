using Common.Application.Models.Results;
using MediatR;

namespace Common.Application.Abstractions.Messaging.Commands;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, OperationResult> where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponseData> : IRequestHandler<TCommand, OperationResult<TResponseData>>
    where TCommand : ICommand<TResponseData>
{
}