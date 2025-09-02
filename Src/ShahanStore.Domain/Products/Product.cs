using Common.Domain.Bases;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;

namespace ShahanStore.Domain.Products;

public class Product : AggregateRoot
{
    public string FaName { get; private set; }
    public string EnName { get; private set; }
    public string Slug { get; private set; }
    public string ProductCode { get; private set; }
    public string? ShortDescription { get; private set; }
    public string? ExpertReview { get; private set; }
    public string MainImg { get; private set; }
    public Guid CategoryId { get; private set; }
    public Guid BrandId { get; private set; }
    public bool IsAvailable { get;private set; }
    public SeoData SeoData { get;private set; }

    public Product()
    {

    }

    private Product(string faName, string enName, string slug, string productCode, string? shortDescription,
        string? expertReview, string mainImg, Guid categoryId, Guid brandId, SeoData seoData)
    {
        Guard(faName, enName, slug, categoryId, brandId);
        DomainGuard.AgainstNullOrEmpty(productCode, nameof(ProductCode));
        DomainGuard.AgainstNullOrEmpty(mainImg, nameof(mainImg));
        FaName = faName;
        EnName = enName;
        Slug = slug;
        ProductCode = productCode;
        ShortDescription = shortDescription;
        ExpertReview = expertReview;
        MainImg = mainImg;
        CategoryId = categoryId;
        BrandId = brandId;
        IsAvailable = true;
        SeoData = seoData;
    }

    public static Product CreateNew(string faName, string enName, string slug, string productCode, string? shortDescription, string? expertReview, string mainImg, Guid categoryId, Guid brandId, SeoData seoData)
    {
        return new Product(faName, enName, slug, productCode, shortDescription, expertReview, mainImg, categoryId, brandId,seoData);
    }

    public void Edit(string faName, string enName, string slug, string? shortDescription,
        string? expertReview, Guid categoryId, Guid brandId, bool isAvailable, SeoData seoData)
    {
        Guard(faName, enName, slug, categoryId, brandId);
        FaName = faName;
        EnName = enName;
        Slug = slug;
        ShortDescription = shortDescription;
        ExpertReview = expertReview;
        CategoryId = categoryId;
        BrandId = brandId;
        IsAvailable = isAvailable;
        SeoData = seoData;
    }

    public void ChangeMainImg(string newMainImg)
    {
        DomainGuard.AgainstNullOrEmpty(newMainImg, nameof(MainImg));
        MainImg = newMainImg;
    }


    public void Delete(bool isAvailable)
    {
        IsAvailable = isAvailable;
    }

    private void Guard(string faName, string enName, string slug, Guid categoryId, Guid brandId)
    {
        DomainGuard.AgainstNullOrEmpty(faName, nameof(FaName));
        DomainGuard.AgainstNullOrEmpty(enName, nameof(EnName));
        DomainGuard.AgainstNullOrEmpty(slug, nameof(Slug));
        DomainGuard.AgainstNullOrEmpty(categoryId, nameof(CategoryId));
        DomainGuard.AgainstNullOrEmpty(brandId,nameof(BrandId));
    }
}
