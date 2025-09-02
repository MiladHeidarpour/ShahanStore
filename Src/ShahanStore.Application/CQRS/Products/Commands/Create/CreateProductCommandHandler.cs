using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using Common.Domain.Utilities;
using ShahanStore.Domain.Categories;
using ShahanStore.Domain.Products;

namespace ShahanStore.Application.CQRS.Products.Commands.Create;
internal sealed class CreateProductCommandHandler(IProductRepository productRepository,IUnitOfWork unitOfWork) : ICommandHandler<CreateProductCommand>
{
    public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (await productRepository.IsSlugDuplicateAsync(request.Slug.ToSlug(), cancellationToken))
            return OperationResult.Error("اسلاگ وارد شده تکراری است.");

        var product = Product.CreateNew(request.FaName, request.EnName, request.Slug.ToSlug(), request.ProductCode,
            request.ShortDescription, request.ExpertReview, request.MainImg, request.CategoryId, request.BrandId);

        productRepository.Add(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult.Success("محصول اضافه شد.");
    }
}
