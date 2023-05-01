namespace PollutionPatrol.BuildingBlocks.Application.Collections;

public abstract class BasePagedList<TSource> : List<TSource>
{
    protected BasePagedList(IEnumerable<TSource> items, int count, int page, int size)
    {
        TotalCount = count;
        CurrentPage = page;
        PageSize = size;
        TotalPages = (int)Math.Ceiling(count / (double)size);

        AddRange(items);
    }

    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}