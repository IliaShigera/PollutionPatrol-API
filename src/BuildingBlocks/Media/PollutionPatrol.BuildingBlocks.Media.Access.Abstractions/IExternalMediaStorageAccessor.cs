namespace PollutionPatrol.BuildingBlocks.Media.Access.Abstractions;

public interface IExternalMediaStorageAccessor
{
    Task<string> UploadMediaAsync(
        Stream media,
        Prefixes prefix,
        string fileName,
        string? folder = default,
        CancellationToken cancellationToken = default);

    Task RemoveMediaAsync(string mediaKey, CancellationToken cancellationToken = default);
    Task<string?> GetMediaUrlAsync(string mediaKey, CancellationToken cancellationToken = default);
    Task<Stream> LoadMediaAsync(string mediaKey, CancellationToken cancellationToken = default);
}