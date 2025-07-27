namespace ShahanStore.API.Common.FileUtil;

public static class FileValidation
{
    // --- تصاویر ---
    private static readonly HashSet<string> ValidImageExtensions = new()
    { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

    private static readonly HashSet<string> ValidImageMimeTypes = new()
    { "image/jpeg", "image/png", "image/gif", "image/webp" };

    // --- ویدیوها ---
    private static readonly HashSet<string> ValidVideoExtensions = new()
    { ".mp4", ".mov", ".mkv", ".avi" };

    private static readonly HashSet<string> ValidVideoMimeTypes = new()
    { "video/mp4", "video/quicktime", "video/x-matroska", "video/x-msvideo" };

    // --- فایل‌های صوتی ---
    private static readonly HashSet<string> ValidAudioExtensions = new()
    { ".mp3", ".wav", ".ogg", ".m4a" };

    private static readonly HashSet<string> ValidAudioMimeTypes = new()
    { "audio/mpeg", "audio/wav", "audio/ogg", "audio/mp4" };

    // --- فایل‌های فشرده ---
    private static readonly HashSet<string> ValidCompressExtensions = new()
    { ".zip", ".rar", ".7z" };

    private static readonly HashSet<string> ValidCompressMimeTypes = new()
    { "application/zip", "application/x-rar-compressed", "application/x-7z-compressed" };

    // --- اسناد ---
    private static readonly HashSet<string> ValidDocumentExtensions = new()
    { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".txt" };

    private static readonly HashSet<string> ValidDocumentMimeTypes = new()
    {
        "application/pdf",
        "application/msword",
        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        "application/vnd.ms-excel",
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        "text/plain"
    };

    // ------------------------------------------------------------------
    // متدهای عمومی ولیدیشن
    // ------------------------------------------------------------------

    public static bool IsValidImageFile(this IFormFile? file) =>
        IsValid(file, ValidImageExtensions, ValidImageMimeTypes);

    public static bool IsValidVideoFile(this IFormFile? file) =>
        IsValid(file, ValidVideoExtensions, ValidVideoMimeTypes);

    public static bool IsValidAudioFile(this IFormFile? file) =>
        IsValid(file, ValidAudioExtensions, ValidAudioMimeTypes);

    public static bool IsValidCompressFile(this IFormFile? file) =>
        IsValid(file, ValidCompressExtensions, ValidCompressMimeTypes);

    public static bool IsValidDocumentFile(this IFormFile? file) =>
        IsValid(file, ValidDocumentExtensions, ValidDocumentMimeTypes);

    // ------------------------------------------------------------------
    // متد اصلی و خصوصی که منطق اصلی ولیدیشن را انجام می‌دهد
    // ------------------------------------------------------------------
    private static bool IsValid(IFormFile? file, HashSet<string> validExtensions, HashSet<string> validMimeTypes)
    {
        if (file == null || file.Length == 0)
            return false;

        var fileExtension = Path.GetExtension(file.FileName)?.ToLowerInvariant();

        // اعتبارسنجی چند لایه: چک کردن همزمان پسوند و MIME Type
        return !string.IsNullOrEmpty(fileExtension) &&
               validExtensions.Contains(fileExtension) &&
               !string.IsNullOrEmpty(file.ContentType) &&
               validMimeTypes.Contains(file.ContentType.ToLowerInvariant());
    }
}