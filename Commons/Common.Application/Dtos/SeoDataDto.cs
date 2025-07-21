namespace Common.Application.Dtos;

public record SeoDataDto(
    // Meta Tags
    string? MetaTitle,
    string? MetaDescription,

    // Indexing and Canonical
    bool IndexPage,
    string? Canonical,
    
    // Social & Rich Snippets
    string? OgTitle,
    string? OgDescription,
    string? OgImage, // آدرس کامل تصویر
    string? Schema);
