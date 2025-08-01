namespace ShahanStore.API.Common.FileUtil.Interfaces;

public interface ILocalFileService
{
    /// <summary>
    ///     یک فایل را در مسیر نسبی مشخصی در web root ذخیره کرده،
    ///     یک نام منحصر به فرد تولید می‌کند و نام جدید فایل را برمی‌گرداند.
    /// </summary>
    Task<string> SaveFileAsync(IFormFile file, string relativePath);

    /// <summary>
    ///     یک فایل را از مسیر نسبی مشخصی در web root حذف می‌کند.
    /// </summary>
    void DeleteFile(string fileName, string relativePath);
}