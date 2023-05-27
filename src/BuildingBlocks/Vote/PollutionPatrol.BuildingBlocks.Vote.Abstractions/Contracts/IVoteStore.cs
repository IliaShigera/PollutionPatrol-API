namespace PollutionPatrol.BuildingBlocks.Vote.Abstractions;

public interface IVoteStore
{
    DbSet<Vote> Votes { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}