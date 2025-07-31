using Common.Domain.Bases;
using Common.Domain.Exceptions;
using Common.Domain.Utilities;
using Common.Domain.ValueObjects;

namespace ShahanStore.Domain.Categories;

public class Category : AggregateRoot
{
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public Guid? ParentId { get; private set; }
    public string? BannerImg { get; private set; }
    public string? Icon { get; private set; }
    public bool IsDeleted { get; private set; }
    public SeoData SeoData { get; private set; }

    private readonly List<CategoryAttribute> _categoryAttributes = new();
    public IReadOnlyCollection<CategoryAttribute> CategoryAttributes => _categoryAttributes.AsReadOnly();



    private Category(string title, string slug, Guid? parentId, string? bannerImg, string? icon, SeoData seoData)
    {
        Guard(title, slug);
        Title = title;
        Slug = slug;
        ParentId = parentId;
        BannerImg = bannerImg;
        Icon = icon;
        SeoData = seoData;
        IsDeleted = false;
    }
    public Category()
    {
        
    }


    public static Category CreateNew(string title, string slug, Guid? parentId, string? bannerImg, string? icon, SeoData seoData)
    {
        return new Category(title, slug, parentId, bannerImg, icon, seoData);
    }
    public void Edit(string title, string slug, SeoData seoData)
    {
        Guard(title, slug);
        Title = title;
        Slug = slug;
        SeoData = seoData;
    }
    public void Delete()
    {
        IsDeleted = true;
    }
    public void ChangeBanner(string newBanner)
    {
        DomainGuard.AgainstNullOrEmpty(newBanner, nameof(BannerImg));
        BannerImg = newBanner;
    }

    public void ChangeIcon(string newIcon)
    {
        DomainGuard.AgainstNullOrEmpty(newIcon, nameof(Icon));
        Icon = newIcon;
    }



    //CategoryAttribute
    public void AddAttribute(string attributeName, List<string> possibleValues)
    {
        if (_categoryAttributes.Any(a => a.Name == attributeName))
        {
            throw new InvalidDomainDataException($"Attribute '{attributeName}' already exists in this category.", nameof(CategoryAttributes));
        }

        var newAttribute = new CategoryAttribute(attributeName, possibleValues, Id);
        _categoryAttributes.Add(newAttribute);
    }

    public void EditAttribute(Guid attributeId, string newName, List<string> newValues)
    {
        var attribute = _categoryAttributes.FirstOrDefault(a => a.Id == attributeId);
        if (attribute == null)
        {
            throw new InvalidDomainDataException("Attribute not found in this category.", nameof(CategoryAttributes));
        }

        if (_categoryAttributes.Any(a => a.Id != attributeId && a.Name == newName))
        {
            throw new InvalidDomainDataException($"Attribute '{newName}' already exists in this category.", nameof(CategoryAttributes));
        }

        attribute.Edit(newName, newValues);
    }

    public void RemoveAttribute(Guid attributeId)
    {
        var attribute = _categoryAttributes.FirstOrDefault(a => a.Id == attributeId);
        if (attribute != null)
        {
            _categoryAttributes.Remove(attribute);
        }
    }


    //Guard
    private void Guard(string title, string slug)
    {
        DomainGuard.AgainstNullOrEmpty(title, nameof(Title));
        DomainGuard.AgainstNullOrEmpty(slug, nameof(Slug));
    }
}