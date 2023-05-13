namespace PollutionPatrol.BuildingBlocks.Media.Access.Abstractions;

public interface IMediaStorageAccessProvider
{
    IDropBoxStorageAccessor DropBox { get; }
}