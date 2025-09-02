namespace Common.Domain.Exceptions;

public static class DomainGuard
{
    public static void AgainstNullOrEmpty<T>(T value, string fieldName)
    {
        bool isEmpty = value switch
        {
            // Specific logic for string
            string s => string.IsNullOrWhiteSpace(s),

            // Specific logic for Guid
            Guid g => g == Guid.Empty,

            // You can add more types here if needed
            // For example, for collections:
            // ICollection c => c.Count == 0,

            // A general check for any other reference type
            not null => false,
            _ => true // Covers null and any other case we define as empty
        };

        if (isEmpty)
            throw new NullOrEmptyDomainDataException(fieldName);
    }

    //public static void AgainstNullOrEmpty(string value, string fieldName)
    //{
    //    if (string.IsNullOrWhiteSpace(value))
    //        throw new NullOrEmptyDomainDataException(fieldName);
    //}
    //public static void AgainstNullOrEmpty(Guid value, string fieldName)
    //{
    //    if (value == Guid.Empty)
    //        throw new NullOrEmptyDomainDataException(nameof(fieldName));
    //}

    public static void AgainstDuplicateSlug(bool isDuplicate)
    {
        if (isDuplicate)
            throw new SlugIsDuplicateException();
    }
}