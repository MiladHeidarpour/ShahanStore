namespace ShahanStore.Application.CQRS.Categories.DTOs.Queries.Filters;

public class BaseFilterResult
{
    public int EntityCount { get; private set; }
    public int CurrentPage { get; private set; }
    public int PageCount { get; private set; }
    public int Take { get; private set; }

    public void GeneratePaging(int entityCount, int take, int currentPage)
    {
        EntityCount = entityCount;
        Take = take;
        CurrentPage = currentPage;
        PageCount = (int)Math.Ceiling(entityCount / (double)take);
    }
}