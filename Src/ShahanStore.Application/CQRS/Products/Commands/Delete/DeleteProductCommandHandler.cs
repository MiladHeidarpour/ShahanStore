using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using ShahanStore.Domain.Products;

namespace ShahanStore.Application.CQRS.Products.Commands.Delete;

internal sealed class DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteProductCommand>
{
    public async Task<OperationResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.FindByIdAsync(request.ProductId,cancellationToken);

        if(product is null)
            return OperationResult.NotFound();

        productRepository.Delete(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult.Success("محصول با موفقیت حذف شد.");
    }
}