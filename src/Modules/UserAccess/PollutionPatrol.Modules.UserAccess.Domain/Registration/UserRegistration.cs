namespace PollutionPatrol.Modules.UserAccess.Domain.Registration;

public sealed class UserRegistration : Entity
{
    private UserRegistration(
        string firstName,
        string emailAddress,
        IEmailValidator emailValidator,
        string passwordHash,
        string salt,
        string confirmationCode,
        DateTime expirationDate)
    {
        CheckRule(new UserEmailMushBeUniqueDomainRule(emailAddress, emailValidator));

        FirstName = firstName;
        EmailAddress = emailAddress;
        PasswordHash = passwordHash;
        Salt = salt;
        ConfirmationCode = confirmationCode;
        ExpirationDate = expirationDate;
        RegistrationDate = DateTime.UtcNow.Date;
        Status = RegistrationStatus.ConfirmationPending;

        AddDomainEvent(new NewUserRegistrationCreatedDomainEvent(FirstName, EmailAddress, ConfirmationCode));
    }

    private UserRegistration()
    {
        // EF only
    }

    public string FirstName { get; init; }
    public string EmailAddress { get; init; }
    public string PasswordHash { get; init; }
    public string Salt { get; init; }
    public string ConfirmationCode { get; init; }
    public DateTime RegistrationDate { get; init; }
    public DateTime ExpirationDate { get; init; }
    public DateTime ConfirmationDate { get; private set; }
    public RegistrationStatus Status { get; private set; }

    public static UserRegistration Create(
        string firstName,
        string emailAddress,
        IEmailValidator emailValidator,
        string passwordHash,
        string salt,
        string confirmationCode,
        DateTime expirationDate)
    {
        return new UserRegistration(
            firstName,
            emailAddress,
            emailValidator,
            passwordHash,
            salt,
            confirmationCode,
            expirationDate);
    }

    public void Confirm()
    {
        CheckRule(new RegistrationCannotBeConfirmedMoreThanOnesDomainRule(Status));
        CheckRule(new RegistrationCannotBeConfirmedWhenAlreadyExpiredDomainRule(Status));

        Status = RegistrationStatus.Confirmed;
        ConfirmationDate = DateTime.UtcNow.Date;

        AddDomainEvent(new UserRegistrationConfirmedDomainEvent(this));
    }

    public void Expire()
    {
        CheckRule(new RegistrationCannotBeExpiredMoreThanOnceDomainRule(Status));
        CheckRule(new RegistrationCannotBeExpiredWhenAlreadyConfirmedDomainRule(Status));
        CheckRule(new RegistrationCannotBeExpiredBeforeExpirationDateDomainRule(ExpirationDate));

        Status = RegistrationStatus.Expired;

        AddDomainEvent(new UserRegistrationExpiredDomainEvent(this));
    }
}