using Common.Domain.Exceptions;
using Common.Domain.Utilities;
using Common.Domain.ValueObjects;
using FluentAssertions;
using ShahanStore.Domain.Categories;

namespace Domain.UnitTest.Entities.Categories;

public class CategoryTest
{
    [Fact]
    public void CreateNew_Should_ReturnCategory_WhenDataIsValid()
    {
        var title = "کالای دیجیتال";
        var slug = "digital-goods";
        var seoData = new SeoData("عنوان سئو", "توضیحات سئو", true, null, null, null, null, null);
        Guid? parentId = null;
        var bannerImg = "banner.jpg";
        var icon = "icon.png";

        var category = Category.CreateNew(title, slug, parentId, bannerImg, icon, seoData);

        category.Should().NotBeNull();
        category.Title.Should().Be(title);
        category.Slug.Should().Be(slug.ToSlug());
        category.ParentId.Should().Be(parentId);
        category.BannerImg.Should().Be(bannerImg);
        category.Icon.Should().Be(icon);
        category.SeoData.Should().Be(seoData);
        category.IsDeleted.Should().BeFalse();
        category.Id.Should().NotBeEmpty();
        category.CreationDate.Should().NotBe(null);
    }


    [Theory]
    [InlineData(null, "some-slug")] // تست با عنوان نال
    [InlineData("", "some-slug")] // تست با عنوان خالی
    [InlineData(" ", "some-slug")] // تست با عنوان فقط فاصله
    [InlineData("some-title", null)] // تست با اسلاگ نال
    [InlineData("some-title", "")] // تست با اسلاگ خالی
    [InlineData("some-title", " ")] // تست با اسلاگ فقط فاصله
    public void CreateNew_Should_ThrowException_WhenTitleOrSlugIsInvalid(string title, string slug)
    {
        var seoData = new SeoData("عنوان سئو", "توضیحات سئو", true, null, null, null, null, null);
        Action act = () => Category.CreateNew(title, slug, null, null, null, seoData);
        act.Should().Throw<NullOrEmptyDomainDataException>();
    }

    [Fact]
    public void Edit_Should_UpdateProperties_WhenDataIsValid()
    {
        var initialSeoData = new SeoData("عنوان قدیمی", "توضیحات قدیمی", true, null, null, null, null, null);
        var category = Category.CreateNew("عنوان اولیه", "initial-slug", null, null, null, initialSeoData);

        var newTitle = "عنوان جدید";
        var newSlug = "new-slug";
        bool newIsDeleted = false;
        var newSeoData = new SeoData("عنوان سئوی جدید", "توضیحات سئوی جدید", false, null, null, null, null, null);

        category.Edit(newTitle, newSlug,newIsDeleted, newSeoData);

        category.Title.Should().Be(newTitle);
        category.Slug.Should().Be(newSlug);
        category.SeoData.Should().Be(newSeoData);
    }

    [Theory]
    [InlineData(null, "some-slug",true)]
    [InlineData("", "some-slug",false)]
    [InlineData("some-title", null,false)]
    [InlineData("some-title", "",true)]
    public void Edit_Should_ThrowException_WhenTitleOrSlugIsInvalid(string newTitle, string newSlug,bool newIsDeleted)
    {
        var seoData = new SeoData("عنوان سئو", "توضیحات سئو", true, null, null, null, null, null);
        var category = Category.CreateNew("عنوان اولیه", "initial-slug", null, null, null, seoData);

        var act = () => category.Edit(newTitle, newSlug,newIsDeleted, seoData);

        act.Should().Throw<NullOrEmptyDomainDataException>();
    }


    [Fact]
    public void Delete_Should_SetIsDeletedToTrue()
    {
        var category = Category.CreateNew("عنوان", "slug", null, null, null, SeoData.CreateEmpty());
        category.Delete();
        category.IsDeleted.Should().BeTrue();
    }

    [Fact]
    public void ChangeBanner_Should_UpdateBannerImgProperty()
    {
        var category = Category.CreateNew("عنوان", "slug", null, null, null, SeoData.CreateEmpty());
        var newBannerName = "new-banner.jpg";

        category.ChangeBanner(newBannerName);
        category.BannerImg.Should().Be(newBannerName);
    }


    [Theory]
    [InlineData(null)]
    public void ChangeBanner_Should_ThrowException_WhenDataIsInvalid(string invalidBannerName)
    {
        var category = Category.CreateNew("عنوان", "slug", null, null, null, SeoData.CreateEmpty());

        var act = () => category.ChangeBanner(invalidBannerName);
        act.Should().Throw<NullOrEmptyDomainDataException>();
    }

    [Fact]
    public void ChangeIcon_Should_UpdateIconProperty()
    {
        var category = Category.CreateNew("عنوان", "slug", null, null, null, SeoData.CreateEmpty());
        var newIconName = "new-icon.png";

        category.ChangeIcon(newIconName);
        category.Icon.Should().Be(newIconName);
    }

    [Theory]
    [InlineData(null)]
    public void ChangeIcon_Should_ThrowException_WhenDataIsInvalid(string invalidIconName)
    {
        var category = Category.CreateNew("عنوان", "slug", null, null, null, SeoData.CreateEmpty());

        var act = () => category.ChangeIcon(invalidIconName);
        act.Should().Throw<NullOrEmptyDomainDataException>();
    }
}