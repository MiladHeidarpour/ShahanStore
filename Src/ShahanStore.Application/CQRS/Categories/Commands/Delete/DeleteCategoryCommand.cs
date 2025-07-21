using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.Models.Results;
using Common.Domain.Repositories;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application.CQRS.Categories.Commands.Delete;

public sealed record DeleteCategoryCommand(Guid CategoryId) : ICommand;

internal class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) :
    ICommandHandler<DeleteCategoryCommand>
{
    public async Task<OperationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.CategoryId);
        if (category is null)
        {
            return OperationResult.NotFound();
        }

        var children = await categoryRepository.GetAllChildrenAsync(request.CategoryId);
        categoryRepository.Delete(category);
        foreach (var child in children)
        {
            child.Delete();
        }
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResult.Success();
    }
}