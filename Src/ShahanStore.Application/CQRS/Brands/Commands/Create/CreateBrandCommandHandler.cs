using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using Common.Domain.Utilities;
using ShahanStore.Domain.Brands;

namespace ShahanStore.Application.CQRS.Brands.Commands.Create;

internal sealed class CreateBrandCommandHandler(IBrandRepository brandRepository,IUnitOfWork unitOfWork) :
    ICommandHandler<CreateBrandCommand>
{
    public async Task<OperationResult> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        if (await brandRepository.IsSlugDuplicateAsync(request.Slug.ToSlug(), cancellationToken))
            return OperationResult.Error("اسلاگ وارد شده تکراری است.");

        var brand = Brand.CreateNew(request.Name, request.Slug.ToSlug(), request.BannerImg, request.Logo,request.Description,
            request.SeoData);

        brandRepository.Add(brand);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult.Success("برند اضافه شد.");
    }
}
