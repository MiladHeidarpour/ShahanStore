using Common.Domain.Bases;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using ShahanStore.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Domain.Brands;

public class Brand : AggregateRoot
{
    private Brand(string name, string slug, string? bannerImg, string? logo, string? description, SeoData seoData)
    {
        Guard(name, slug);
        Name = name;
        Slug = slug;
        BannerImg = bannerImg;
        Logo = logo;
        Description = description;
        SeoData = seoData;
        IsAvailable = true;
    }
    public Brand()
    {
    }


    public string Name { get; private set; }
    public string Slug { get; private set; }
    public string? BannerImg { get; private set; }
    public string? Logo { get; private set; }
    public string? Description { get; private set; }
    public bool IsAvailable { get; private set; }
    public SeoData SeoData { get; private set; }


    public static Brand CreateNew(string name, string slug, string? bannerImg, string? logo, string? description, SeoData seoData)
    {
        return new Brand(name, slug, bannerImg, logo, description, seoData);
    }

    public void Edit(string name, string slug, string? description, bool isAvailable, SeoData seoData)
    {
        Guard(name, slug);
        Name = name;
        Slug = slug;
        Description = description;
        IsAvailable = isAvailable;
        SeoData = seoData;
    }

    public void Delete()
    {
        IsAvailable = false;
    }

    public void ChangeBanner(string newBanner)
    {
        DomainGuard.AgainstNullOrEmpty(newBanner, nameof(BannerImg));
        BannerImg = newBanner;
    }

    public void ChangeLogo(string newLogo)
    {
        DomainGuard.AgainstNullOrEmpty(newLogo, nameof(Logo));
        Logo = newLogo;
    }

    private void Guard(string name, string slug)
    {
        DomainGuard.AgainstNullOrEmpty(name, nameof(Name));
        DomainGuard.AgainstNullOrEmpty(slug, nameof(Slug));
    }
}
