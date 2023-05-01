namespace PollutionPatrol.BuildingBlocks.Application.Interfaces;

public interface IDomainEventHandler<in TDomainEvent> :
    INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
}