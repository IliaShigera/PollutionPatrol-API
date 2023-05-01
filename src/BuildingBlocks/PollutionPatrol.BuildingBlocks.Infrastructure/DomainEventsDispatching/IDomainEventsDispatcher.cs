namespace PollutionPatrol.BuildingBlocks.Infrastructure.DomainEventsDispatching;

public interface IDomainEventsDispatcher
{
    Task DispatchEventsAsync(DbContext dbContext, CancellationToken cancellationToken = default);
}