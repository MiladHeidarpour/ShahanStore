namespace Common.Domain.Exceptions;

public class InvalidDomainDataException : BaseDomainException
{
    public InvalidDomainDataException()
    {
    }

    public InvalidDomainDataException(string message, string fieldName) : base(message)
    {
        FieldName = fieldName;
    }

    public string? FieldName { get; }
}