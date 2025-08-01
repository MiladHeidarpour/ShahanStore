using System.Text;
using System.Text.RegularExpressions;

namespace Common.Domain.Utilities;

public static class TextHelper
{
    private static readonly Random _random = new();

    public static string ToSlug(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return "";

        // حذف کاراکترهای غیرمجاز و جایگزینی فاصله‌ها با خط تیره
        var slug = Regex.Replace(text.Trim().ToLower(), @"[^a-z0-9\s-]",
            ""); // فقط حروف انگلیسی، اعداد، فاصله و خط تیره مجاز است
        slug = Regex.Replace(slug, @"\s+", "-"); // تبدیل فاصله‌های متعدد به یک خط تیره
        slug = Regex.Replace(slug, @"-+", "-"); // تبدیل خط تیره های متعدد به یک خط تیره

        return slug.Trim('-');
    }

    public static string GenerateCode(int length)
    {
        const string chars = "0123456789";
        var stringBuilder = new StringBuilder(length);

        for (var i = 0; i < length; i++) stringBuilder.Append(chars[_random.Next(chars.Length)]);

        return stringBuilder.ToString();
    }

    public static string Truncate(this string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text) || text.Length <= maxLength) return text;

        // اطمینان از اینکه طول متن برای اضافه کردن "..." کافی است
        if (maxLength <= 3) return "...";

        return text.Substring(0, maxLength - 3) + "...";
    }

    public static string ObfuscateEmail(this string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            return email;

        var parts = email.Split('@');
        var localPart = parts[0];
        var domain = parts[1];

        if (localPart.Length <= 2) return $"{localPart[0]}***@{domain}";

        return $"{localPart.Substring(0, 2)}***@{domain}";
    }

    public static bool ContainsNonDigits(this string value)
    {
        var isNumber = Regex.IsMatch(value, @"^\d+$");
        return !isNumber;
    }

    public static bool ContainsNonAscii(this string value)
    {
        return value.Any(c => c > 255);
    }
}