using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Commands.Delete;

internal sealed class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) :
    ICommandHandler<DeleteCategoryCommand>
{
    public async Task<OperationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.FindByIdWithDetailsAsync(request.CategoryId, cancellationToken);
        if (category is null) return OperationResult.NotFound();

        categoryRepository.Delete(category);
        foreach (var child in category.Children) child.Delete();

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult.Success("دسته‌بندی با موفقیت حذف شد.");
    }
}