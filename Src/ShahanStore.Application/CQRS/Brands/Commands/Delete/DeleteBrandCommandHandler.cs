using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using ShahanStore.Domain.Brands;

namespace ShahanStore.Application.CQRS.Brands.Commands.Delete;

internal sealed class DeleteBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork) :
    ICommandHandler<DeleteBrandCommand>
{
    public async Task<OperationResult> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.FindByIdAsync(request.BrandId, cancellationToken);
        if (brand is null) return OperationResult.NotFound();

        brandRepository.Delete(brand);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult.Success("برند با موفقیت حذف شد.");
    }
}