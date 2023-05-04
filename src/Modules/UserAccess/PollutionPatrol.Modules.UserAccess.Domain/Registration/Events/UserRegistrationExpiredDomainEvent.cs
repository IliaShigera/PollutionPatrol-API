namespace PollutionPatrol.Modules.UserAccess.Domain.Registration.Events;

public sealed class UserRegistrationExpiredDomainEvent : IDomainEvent
{
    internal UserRegistrationExpiredDomainEvent(string firstName, string emailAddress)
    {
        FirstName = firstName;
        EmailAddress = emailAddress;
    }

    public string FirstName { get; init; }
    public string EmailAddress { get; init; }
}