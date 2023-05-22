namespace PollutionPatrol.BuildingBlocks.Media.Access.Abstractions;

public interface IExternalMediaStorageAccessor
{
    Task<MediaKey> UploadMediaAsync(
        Stream mediaStream,
        string mediaName,
        IReadOnlyList<string>? folderStructure = default,
        CancellationToken cancellationToken = default);

    Task RemoveMediaAsync(MediaKey mediaKey, CancellationToken cancellationToken = default);
    Task<string?> GetMediaUrlAsync(MediaKey mediaKey, CancellationToken cancellationToken = default);
    Task<Stream> LoadMediaAsync(MediaKey mediaKey, CancellationToken cancellationToken = default);
}