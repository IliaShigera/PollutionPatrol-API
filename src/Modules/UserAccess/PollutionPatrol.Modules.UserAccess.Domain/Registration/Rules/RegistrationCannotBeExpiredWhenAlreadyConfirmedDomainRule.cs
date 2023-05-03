namespace PollutionPatrol.Modules.UserAccess.Domain.Registration.Rules;

internal sealed class RegistrationCannotBeExpiredWhenAlreadyConfirmedDomainRule : IDomainRule
{
    private readonly RegistrationStatus _status;

    internal RegistrationCannotBeExpiredWhenAlreadyConfirmedDomainRule(RegistrationStatus status) => _status = status;

    public string Message => "This registration has already been confirmed and cannot be expired.";

    public bool IsBroken() => _status.Value.Equals(RegistrationStatus.Confirmed.Value);
}