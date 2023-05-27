namespace PollutionPatrol.BuildingBlocks.Vote.Abstractions;

public sealed class Vote
{
    public Vote(Guid itemId, Guid voterId, VoteType voteType)
    {
        ItemId = itemId;
        VoterId = voterId;
        VoteType = voteType;
    }

    private Vote() { }

    public Guid Id { get; private set; }
    public Guid ItemId { get; init; }
    public Guid VoterId { get; init; }
    public VoteType VoteType { get; init; }
}