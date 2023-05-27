namespace PollutionPatrol.BuildingBlocks.Vote.Abstractions;

public interface IVoteManager
{
    Task UpVoteAsync(Guid itemId, Guid voterId, CancellationToken cancellationToken = default);
    Task DownVoteAsync(Guid itemId, Guid voterId, CancellationToken cancellationToken = default);
    Task RemoveVoteAsync(Guid itemId, Guid voterId, CancellationToken cancellationToken = default);
}