namespace PollutionPatrol.BuildingBlocks.Media.Access.DropBox;

internal sealed class DropBoxStorageAccessor : IDropBoxStorageAccessor
{
    private readonly DropboxClient _client;

    public DropBoxStorageAccessor(IOptions<DropBoxOptions> options)
    {
        var dropBox = options.Value;

        _client = new DropboxClient(dropBox.AuthToken);
    }

    public async Task<MediaKey> UploadMediaAsync(
        Stream mediaStream,
        string mediaName,
        IReadOnlyList<string>? folderStructure = default,
        CancellationToken cancellationToken = default)
    {
        if (mediaStream is null)
            throw new ArgumentNullException(nameof(mediaStream), "Media is required and cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(mediaName))
            throw new ArgumentNullException(nameof(mediaName), "Media name is required and cannot be null or empty.");

        var mediaMetadata = await _client.Files.UploadAsync(
            path: CreateMediaPath(mediaName, folderStructure),
            mode: WriteMode.Overwrite.Instance,
            body: mediaStream);

        var keyValue = mediaMetadata.PathDisplay[1..]; // removing '/' at the beginning of a string
        return new MediaKey(keyValue);
    }

    public async Task RemoveMediaAsync(MediaKey mediaKey, CancellationToken cancellationToken = default)
    {
        if (mediaKey is null || string.IsNullOrWhiteSpace(mediaKey.Value))
            throw new ArgumentNullException(nameof(mediaKey), "Media key is required and cannot be null or empty.");

        await _client.Files.DeleteV2Async($"/{mediaKey.Value}");
    }

    public async Task<string?> GetMediaUrlAsync(MediaKey mediaKey, CancellationToken cancellationToken = default)
    {
        var existingSharedLinks = await _client.Sharing.ListSharedLinksAsync($"/{mediaKey.Value}");
        var sharedLinkMetadata = existingSharedLinks.Links.FirstOrDefault() ??
                                 await _client.Sharing.CreateSharedLinkWithSettingsAsync($"/{mediaKey.Value}");

        return sharedLinkMetadata.Url;
    }

    public async Task<Stream> LoadMediaAsync(MediaKey mediaKey, CancellationToken cancellationToken = default)
    {
        if (mediaKey is null || string.IsNullOrWhiteSpace(mediaKey.Value))
            throw new ArgumentNullException(nameof(mediaKey), "Media key is required and cannot be null or empty.");

        var response = await _client.Files.DownloadAsync($"/{mediaKey.Value}");
        return await response.GetContentAsStreamAsync();
    }

    private string CreateMediaPath(string mediaName, IReadOnlyList<string>? folderStructure)
    {
        var path = new StringBuilder("/");

        if (folderStructure is not null && folderStructure.Any())
            foreach (var folder in folderStructure)
                path.Append($"{folder}/");

        path.Append($"{Guid.NewGuid()}");
        path.Append(Path.GetExtension(mediaName));

        return string.Concat(path);
    }
}