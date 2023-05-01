namespace PollutionPatrol.BuildingBlocks.Infrastructure.DomainEventsDispatching;

public interface IDomainEventsAccessor
{
    IReadOnlyCollection<IDomainEvent> GetAllDomainEvents(DbContext dbContext);

    void ClearAllDomainEvents(DbContext dbContext);
}