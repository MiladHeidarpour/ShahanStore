using MediatR;

namespace Common.Application.Abstractions.Messaging.Queries;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse> where TResponse : class?
{

}