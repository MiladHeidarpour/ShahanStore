using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using ShahanStore.Domain.Products;

namespace ShahanStore.Application.CQRS.Products.Commands.ChangeMainImg;

internal class ChangeProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<ChangeProductMainImgCommand, string?>
{
    public async Task<OperationResult<string?>> Handle(ChangeProductMainImgCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.FindByIdAsync(request.ProductId, cancellationToken);

        if (product is null) return OperationResult<string?>.NotFound();

        var oldMainImg = product.MainImg;
        product.ChangeMainImg(request.MainImg);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult<string?>.Success(oldMainImg);
    }
}
