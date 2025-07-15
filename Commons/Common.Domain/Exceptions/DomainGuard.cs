namespace Common.Domain.Exceptions;

public static class DomainGuard
{
    public static void AgainstNullOrEmpty(string value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new NullOrEmptyDomainDataException(fieldName);
    }

    public static void AgainstDuplicateSlug(bool isDuplicate)
    {
        if (isDuplicate)
            throw new SlugIsDuplicateException();
    }
}