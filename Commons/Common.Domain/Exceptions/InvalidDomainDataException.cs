namespace Common.Domain.Exceptions;

public class InvalidDomainDataException : BaseDomainException
{
    public string? FieldName { get; }
    public InvalidDomainDataException()
    {

    }
    public InvalidDomainDataException(string message, string fieldName) : base(message)
    {
        FieldName = fieldName;
    }
}