using System.Text.RegularExpressions;
using Common.Domain.Bases;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    public const int RequiredLength = 11;

    private PhoneNumber()
    {
    }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidDomainDataException("Phone number cannot be empty.", nameof(Value));

        if (value.Length != RequiredLength)
            throw new InvalidDomainDataException($"Phone number must be {RequiredLength} digits.", nameof(Value));

        // ۴. استفاده از Regex برای چک کردن اینکه تمام کاراکترها عدد هستند
        if (!Regex.IsMatch(value, @"^\d+$"))
            throw new InvalidDomainDataException("Phone number can only contain digits.", nameof(Value));

        Value = value;
    }

    public string Value { get; private set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}