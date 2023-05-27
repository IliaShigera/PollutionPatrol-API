namespace PollutionPatrol.BuildingBlocks.Vote.Service.Manager;

internal sealed class VoteManager : IVoteManager
{
    private readonly IVoteStore _voteStore;

    public VoteManager(IVoteStore voteStore) => _voteStore = voteStore;

    public async Task UpVoteAsync(Guid itemId, Guid voterId, CancellationToken cancellationToken = default)
    {
        var vote = await GetVote(itemId, voterId, cancellationToken);

        if (vote is null)
        {
            vote = new Abstractions.Vote(itemId, voterId, VoteType.Up);
            await _voteStore.Votes.AddAsync(vote, cancellationToken);
            await _voteStore.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task DownVoteAsync(Guid itemId, Guid voterId, CancellationToken cancellationToken = default)
    {
        var vote = await GetVote(itemId, voterId, cancellationToken);
        
        if (vote is null)
        {
            vote = new Abstractions.Vote(itemId, voterId, VoteType.Down);
            await _voteStore.Votes.AddAsync(vote, cancellationToken);
            await _voteStore.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task RemoveVoteAsync(Guid itemId, Guid voterId, CancellationToken cancellationToken = default)
    {
        var vote = await GetVote(itemId, voterId, cancellationToken);

        if (vote is not null)
        {
            _voteStore.Votes.Remove(vote);
            await _voteStore.SaveChangesAsync(cancellationToken);
        }
    }

    private async Task<Abstractions.Vote?> GetVote(Guid itemId, Guid voterId, CancellationToken cancellationToken)
    {
        return await _voteStore.Votes.FirstOrDefaultAsync(v => v.ItemId.Equals(itemId) &&
                                                               v.VoterId.Equals(voterId), cancellationToken);
    }
}