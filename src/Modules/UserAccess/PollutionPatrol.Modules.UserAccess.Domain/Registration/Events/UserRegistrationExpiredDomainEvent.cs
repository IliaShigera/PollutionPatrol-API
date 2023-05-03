namespace PollutionPatrol.Modules.UserAccess.Domain.Registration.Events;

public sealed class UserRegistrationExpiredDomainEvent : IDomainEvent
{
    internal UserRegistrationExpiredDomainEvent(UserRegistration registration) => Registration = registration;

    public UserRegistration Registration { get; init; }
}