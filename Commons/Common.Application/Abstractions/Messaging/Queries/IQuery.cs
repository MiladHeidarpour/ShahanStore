using MediatR;

namespace Common.Application.Abstractions.Messaging.Queries;

public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : class?
{
}