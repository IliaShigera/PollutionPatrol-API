namespace PollutionPatrol.Modules.UserAccess.Domain.Registration.Rules;

internal sealed class RegistrationCannotBeConfirmedWhenAlreadyExpiredDomainRule : IDomainRule
{
    private readonly RegistrationStatus _status;

    internal RegistrationCannotBeConfirmedWhenAlreadyExpiredDomainRule(RegistrationStatus status) => _status = status;

    public string Message => "This registration has already been expired and cannot be confirmed.";

    public bool IsBroken() => _status.Value.Equals(RegistrationStatus.Expired.Value);
}