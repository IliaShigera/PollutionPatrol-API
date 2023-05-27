namespace PollutionPatrol.BuildingBlocks.Vote.Service.Counter;

internal sealed class VoteCounter : IVoteCounter
{
    private readonly IVoteStore _voteStore;

    public VoteCounter(IVoteStore voteStore) => _voteStore = voteStore;


    public async Task<int> GetUpVotesAsync(Guid itemId, CancellationToken cancellationToken = default)
    {
        return await _voteStore.Votes.CountAsync(v => v.ItemId.Equals(itemId) &&
                                                      v.VoteType.Equals(VoteType.Up), cancellationToken);
    }

    public async Task<int> GetDownVotesAsync(Guid itemId, CancellationToken cancellationToken = default)
    {
        return await _voteStore.Votes.CountAsync(v => v.ItemId.Equals(itemId) &&
                                                      v.VoteType.Equals(VoteType.Down), cancellationToken);
    }

    public async Task<int> GetTotalVotesAsync(Guid itemId, CancellationToken cancellationToken = default)
    {
        return await _voteStore.Votes.CountAsync(v => v.ItemId.Equals(itemId), cancellationToken);
    }
}