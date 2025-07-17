using Common.Application.Abstractions.Messaging.Commands;
using MediatR;
using FluentValidation;
using Common.Domain.Exceptions;
using ValidationException = Common.Domain.Exceptions.ValidationException;
namespace Common.Application.Behaviors;

internal sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }


    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next(cancellationToken);
        }
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        // حالا ما یک لیست ساختاریافته از خطاها داریم
        var errors = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .Select(f => new ValidationError(f.PropertyName, f.ErrorMessage))
            .Distinct()
            .ToList();

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        return await next(cancellationToken);
    }
}