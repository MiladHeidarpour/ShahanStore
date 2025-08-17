using Common.Application.Abstractions.Messaging.Queries;

namespace ShahanStore.Application.CQRS.Categories.DTOs.Queries.Filters;

public class QueryFilter<TResponse, TParam> : IQuery<TResponse> where TResponse : BaseFilter where TParam : BaseFilterParam
{
    public TParam FilterParams { get; set; }
    public QueryFilter(TParam filterParams)
    {
        FilterParams = filterParams;
    }
}