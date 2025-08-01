namespace Common.Domain.Exceptions;

public record ValidationError(string PropertyName, string ErrorMessage);

public class ValidationException : Exception
{
    public ValidationException(IReadOnlyCollection<ValidationError> errors) : base("Validation Failed")
    {
        Errors = errors;
    }

    public IReadOnlyCollection<ValidationError> Errors { get; }
}