namespace PollutionPatrol.BuildingBlocks.Vote.Abstractions;

public interface IVoteCounter
{
    Task<int> GetUpVotesAsync(Guid itemId, CancellationToken cancellationToken = default);
    Task<int> GetDownVotesAsync(Guid itemId, CancellationToken cancellationToken = default);
    Task<int> GetTotalVotesAsync(Guid itemId, CancellationToken cancellationToken = default);
}