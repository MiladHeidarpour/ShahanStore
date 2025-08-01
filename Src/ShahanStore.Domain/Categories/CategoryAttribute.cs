using Common.Domain.Bases;
using Common.Domain.Exceptions;

namespace ShahanStore.Domain.Categories;

public class CategoryAttribute : BaseEntity
{
    public CategoryAttribute(string name, List<string> possibleValues, Guid categoryId)
    {
        DomainGuard.AgainstNullOrEmpty(name, nameof(Name));

        if (categoryId == Guid.Empty)
            throw new InvalidDomainDataException("CategoryId cannot be empty.", nameof(categoryId));

        Name = name;
        PossibleValues = possibleValues;
        CategoryId = categoryId;
    }

    public Guid CategoryId { get; private set; }
    public string Name { get; private set; }
    public List<string> PossibleValues { get; private set; }

    public void Edit(string name, List<string> possibleValues)
    {
        DomainGuard.AgainstNullOrEmpty(name, nameof(Name));
        Name = name;
        PossibleValues = possibleValues;
    }
}