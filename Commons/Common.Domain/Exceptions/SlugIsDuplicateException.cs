namespace Common.Domain.Exceptions;

public class SlugIsDuplicateException : InvalidDomainDataException
{
    public SlugIsDuplicateException(string? fieldName = "Slug") : base("اسلاگ تکراری است", fieldName)
    {
    }
}