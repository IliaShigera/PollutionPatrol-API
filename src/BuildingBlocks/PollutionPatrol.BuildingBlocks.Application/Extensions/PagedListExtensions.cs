namespace PollutionPatrol.BuildingBlocks.Application.Extensions;

public static class PagedListExtensions
{
    public static string GetPaginationMetadataJson<TSource>(this BasePagedList<TSource> list)
    {
        var metadata = new
        {
            totalCount = list.TotalCount,
            pageSize = list.PageSize,
            currentPage = list.CurrentPage,
            totalPages = list.TotalPages,
            hasNext = list.HasNext,
            hasPrevious = list.HasPrevious
        };

        return JsonConvert.SerializeObject(metadata);
    }
}