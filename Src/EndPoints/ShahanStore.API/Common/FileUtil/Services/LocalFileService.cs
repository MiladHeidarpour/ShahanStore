using ShahanStore.API.Common.FileUtil.Interfaces;

namespace ShahanStore.API.Common.FileUtil.Services;

public class LocalFileService:ILocalFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public LocalFileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<string> SaveFileAsync(IFormFile file, string relativePath)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("فایل نمی‌تواند خالی باشد.", nameof(file));
        }

        // ۱. گرفتن مسیر پایه امن (مثلاً C:\path\to\project\wwwroot)
        var basePath = _webHostEnvironment.WebRootPath;

        // ۲. ترکیب با مسیر نسبی که توسط توسعه‌دهنده ارائه شده
        var directoryPath = Path.Combine(basePath, relativePath);

        // ۳. اطمینان از وجود دایرکتوری
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // ۴. تولید یک نام فایل امن و منحصر به فرد
        var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var finalFilePath = Path.Combine(directoryPath, uniqueFileName);

        // ۵. ذخیره فایل
        await using var stream = new FileStream(finalFilePath, FileMode.Create);
        await file.CopyToAsync(stream);

        // ۶. برگرداندن فقط نام منحصر به فرد برای ذخیره در دیتابیس
        return uniqueFileName;
    }
    public void DeleteFile(string fileName, string relativePath)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            return;

        var basePath = _webHostEnvironment.WebRootPath;
        var filePath = Path.Combine(basePath, relativePath, fileName);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}