namespace PollutionPatrol.BuildingBlocks.Application.Extensions;

public static class QueryableExtensions
{
    public static async Task<PagedList<TSource>> ToPagedListAsync<TSource>(
        this IQueryable<TSource> source, int page, int size, CancellationToken cancellationToken) =>
        await PagedList<TSource>.ToPagedListAsync(source, page, size, cancellationToken);

    public static async Task<ReadOnlyPagedList<TSource>> ToReadOnlyPagedListAsync<TSource>(
        this IQueryable<TSource> source, int page, int size, CancellationToken cancellationToken) =>
        await ReadOnlyPagedList<TSource>.ToReadOnlyPagedListAsync(source, page, size, cancellationToken);
}