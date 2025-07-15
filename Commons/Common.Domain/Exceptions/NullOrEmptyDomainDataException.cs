namespace Common.Domain.Exceptions;

public class NullOrEmptyDomainDataException : InvalidDomainDataException
{
    public NullOrEmptyDomainDataException(string fieldName) : base($"{fieldName} خالی است!", fieldName) { }
}