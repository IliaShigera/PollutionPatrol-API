namespace PollutionPatrol.BuildingBlocks.Media.Access;

internal sealed class MediaStorageAccessProvider : IMediaStorageAccessProvider
{
    public MediaStorageAccessProvider(IDropBoxStorageAccessor dropBoxStorageAccessor)
    {
        DropBox = dropBoxStorageAccessor;
    }

    public IDropBoxStorageAccessor DropBox { get; }
}