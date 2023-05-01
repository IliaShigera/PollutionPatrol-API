namespace PollutionPatrol.BuildingBlocks.Domain.Models;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    private List<IDomainEvent>? _domainEvents;
    public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents ??= new List<IDomainEvent>();

        _domainEvents?.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents?.Clear();

    protected void CheckRule(IDomainRule rule)
    {
        if (rule.IsBroken())
            throw new DomainRuleBrokenException(rule);
    }
}