namespace PollutionPatrol.Modules.UserAccess.Domain.Registration.Rules;

internal sealed class RegistrationCannotBeExpiredBeforeExpirationDateDomainRule : IDomainRule
{
    private readonly DateTime _expirationDate;

    internal RegistrationCannotBeExpiredBeforeExpirationDateDomainRule(DateTime expirationDate) => _expirationDate = expirationDate;

    public string Message => $"This registration cannot be expired before the expiration date of {_expirationDate}." +
                             " Please contact our support if you need assistance.";

    public bool IsBroken() => DateTime.UtcNow.Date < _expirationDate.Date;
}