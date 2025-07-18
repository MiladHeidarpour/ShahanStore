namespace Common.Application.Validations;

public class ValidationMessages
{
    public const string required = "وارد کردن این فیلد اجباری است";
    public const string invalidPhoneNumber = "شماره تلفن نامعتبر است";
    public const string notFound = "اطلاعات درخواستی یافت نشد";
    public const string maxLength = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز است";
    public const string minLength = "تعداد کاراکتر های وارد شده کمتر از حد مجاز است";

    public static string Required(string field) => $"وارد کردن فیلد {field} اجباری است";
    public static string MaxLength(string field, int maxLength) => $"{field} باید کمتر از {maxLength} کاراکتر باشد";
    public static string MinLength(string field, int minLength) => $"{field} باید بیشتر از {minLength} کاراکتر باشد";
}