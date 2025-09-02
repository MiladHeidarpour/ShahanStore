using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using Common.Domain.Utilities;
using ShahanStore.Domain.Products;

namespace ShahanStore.Application.CQRS.Products.Commands.Edit;

internal sealed class EditProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) :
    ICommandHandler<EditProductCommand>
{
    public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId,cancellationToken);
        if (product is null)
            return OperationResult.NotFound();

        var newSlug = request.Slug.ToSlug();
        if (product.Slug != newSlug)
            if (await productRepository.IsSlugDuplicateAsync(newSlug, cancellationToken))
                return OperationResult.Error("اسلاگ وارد شده تکراری است.");

        product.Edit(request.FaName,request.EnName,newSlug,
            request.ShortDescription,request.ExpertReview,request.CategoryId,request.BrandId,request.IsAvailable);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult.Success("محصول با موفقیت ویرایش شد.");
    }
}
