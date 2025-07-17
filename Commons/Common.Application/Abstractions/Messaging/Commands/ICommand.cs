using Common.Application.Models.Results;
using MediatR;

namespace Common.Application.Abstractions.Messaging.Commands;

public interface ICommand : IRequest<OperationResult>
{
}

public interface ICommand<TData> : IRequest<OperationResult<TData>>
{
}