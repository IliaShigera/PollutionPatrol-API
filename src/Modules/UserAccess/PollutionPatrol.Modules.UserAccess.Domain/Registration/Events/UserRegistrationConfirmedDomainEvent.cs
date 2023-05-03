namespace PollutionPatrol.Modules.UserAccess.Domain.Registration.Events;

public sealed class UserRegistrationConfirmedDomainEvent : IDomainEvent
{
    internal UserRegistrationConfirmedDomainEvent(UserRegistration registration) => Registration = registration;

    public UserRegistration Registration { get; init; }
}