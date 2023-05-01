namespace PollutionPatrol.BuildingBlocks.Application.Interfaces;

public interface IDbContext
{
    Task CommitAsync(CancellationToken cancellationToken = default);
}