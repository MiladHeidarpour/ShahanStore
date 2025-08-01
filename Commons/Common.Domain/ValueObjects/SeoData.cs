﻿using Common.Domain.Bases;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects;

public class SeoData : ValueObject
{
    private SeoData()
    {
    }

    public SeoData(string? metaTitle, string? metaDescription, bool indexPage, string? canonical,
        string? ogTitle, string? ogDescription, string? ogImage, string? schema)
    {
        if (metaTitle?.Length > 70)
            throw new InvalidDomainDataException("Meta title cannot be longer than 70 characters.", nameof(metaTitle));

        if (metaDescription?.Length > 160)
            throw new InvalidDomainDataException("Meta description cannot be longer than 160 characters.",
                nameof(metaDescription));

        MetaTitle = metaTitle;
        MetaDescription = metaDescription;
        IndexPage = indexPage;
        Canonical = canonical;
        OgTitle = ogTitle;
        OgDescription = ogDescription;
        OgImage = ogImage;
        Schema = schema;
    }

    // Meta Tags
    public string? MetaTitle { get; }
    public string? MetaDescription { get; }


    // Indexing and Canonical
    public bool IndexPage { get; }
    public string? Canonical { get; }


    // Social & Rich Snippets
    public string? OgTitle { get; }
    public string? OgDescription { get; }
    public string? OgImage { get; } // آدرس کامل تصویر
    public string? Schema { get; }


    public static SeoData CreateEmpty()
    {
        return new SeoData();
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return MetaTitle;
        yield return MetaDescription;
        yield return IndexPage;
        yield return Canonical;
        yield return OgTitle;
        yield return OgDescription;
        yield return OgImage;
        yield return Schema;
    }
}