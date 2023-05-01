namespace PollutionPatrol.BuildingBlocks.Application.Collections;

public class ReadOnlyPagedList<TSource> : BasePagedList<TSource>
{
    private ReadOnlyPagedList(IList<TSource> items, int count, int page, int size) 
        : base(items, count, page, size)
    {
    }

    public static async Task<ReadOnlyPagedList<TSource>> ToReadOnlyPagedListAsync(IQueryable<TSource> source, int page, int size, CancellationToken cancellationToken)
    {
        var count = await source.CountAsync(cancellationToken);
        var items = await source.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);

        return new ReadOnlyPagedList<TSource>(items, count, page, size);
    }
}