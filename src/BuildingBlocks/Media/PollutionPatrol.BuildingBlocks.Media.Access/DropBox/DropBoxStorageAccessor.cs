namespace PollutionPatrol.BuildingBlocks.Media.Access.DropBox;

internal sealed class DropBoxStorageAccessor : IDropBoxStorageAccessor
{
    private readonly DropboxClient _client;

    public DropBoxStorageAccessor(IOptions<DropBoxOptions> options)
    {
        var dropBox = options.Value;

        _client = new DropboxClient(dropBox.AuthToken);
    }

    public async Task<string> UploadMediaAsync(
        Stream media,
        Prefixes prefix,
        string fileName,
        string? folder = default,
        CancellationToken cancellationToken = default)
    {
        if (media is null)
            throw new ArgumentNullException(nameof(media), "Media is required and cannot be null or empty.");

        var fileMetadata = await _client.Files.UploadAsync(
            GetMediaPath(prefix, fileName, folder),
            mode: WriteMode.Overwrite.Instance,
            body: media);

        return fileMetadata.PathDisplay;
    }

    public async Task RemoveMediaAsync(string mediaKey, CancellationToken cancellationToken = default)
    {
        if (mediaKey is null)
            throw new ArgumentNullException(nameof(mediaKey), "Media key is required and cannot be null or empty.");

        await _client.Files.DeleteV2Async(mediaKey);
    }

    public async Task<string?> GetMediaUrlAsync(string mediaKey, CancellationToken cancellationToken = default)
    {
        if (mediaKey is null)
            throw new ArgumentNullException(nameof(mediaKey), "Media key is required and cannot be null or empty.");

        var existingSharedLinks = await _client.Sharing.ListSharedLinksAsync(mediaKey);
        var sharedLinkMetadata = existingSharedLinks.Links.FirstOrDefault() ??
                                 await _client.Sharing.CreateSharedLinkWithSettingsAsync(mediaKey);

        return sharedLinkMetadata.Url;
    }

    public async Task<Stream> LoadMediaAsync(string mediaKey, CancellationToken cancellationToken = default)
    {
        if (mediaKey is null)
            throw new ArgumentNullException(nameof(mediaKey), "Media key is required and cannot be null or empty.");

        var response = await _client.Files.DownloadAsync(mediaKey);
        return await response.GetContentAsStreamAsync();
    }

    private string GetMediaPath(Prefixes prefix, string fileName, string? folder) =>
        string.IsNullOrWhiteSpace(folder)
            ? $"/{prefix}_{fileName}"
            : $"/{prefix}_{folder}/{fileName}";
}