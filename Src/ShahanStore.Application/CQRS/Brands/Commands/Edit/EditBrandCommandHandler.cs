using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using Common.Domain.Utilities;
using ShahanStore.Domain.Brands;

namespace ShahanStore.Application.CQRS.Brands.Commands.Edit;

internal sealed class EditBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork) :
    ICommandHandler<EditBrandCommand>
{
    public async Task<OperationResult> Handle(EditBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.FindByIdAsync(request.Id, cancellationToken);
        if (brand is null) return OperationResult.NotFound();

        var newSlug = request.Slug.ToSlug();
        if (brand.Slug != newSlug)
            if (await brandRepository.IsSlugDuplicateAsync(newSlug, cancellationToken))
                return OperationResult.Error("اسلاگ وارد شده تکراری است.");

        brand.Edit(request.Name, newSlug,request.Description, request.IsAvailable, request.SeoData);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult.Success("برند با موفقیت ویرایش شد.");
    }
}
