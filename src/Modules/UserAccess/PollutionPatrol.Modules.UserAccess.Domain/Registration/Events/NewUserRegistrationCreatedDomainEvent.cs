namespace PollutionPatrol.Modules.UserAccess.Domain.Registration.Events;

public sealed class NewUserRegistrationCreatedDomainEvent : IDomainEvent
{
    internal NewUserRegistrationCreatedDomainEvent(string firstName, string emailAddress, string confirmationCode)
    {
        FirstName = firstName;
        EmailAddress = emailAddress;
        ConfirmationCode = confirmationCode;
    }

    public string FirstName { get; init; }
    public string EmailAddress { get; init; }
    public string ConfirmationCode { get; init; }
}