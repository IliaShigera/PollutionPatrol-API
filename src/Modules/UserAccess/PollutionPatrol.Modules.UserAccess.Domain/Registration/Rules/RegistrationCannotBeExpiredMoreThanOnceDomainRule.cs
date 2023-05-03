namespace PollutionPatrol.Modules.UserAccess.Domain.Registration.Rules;

internal sealed class RegistrationCannotBeExpiredMoreThanOnceDomainRule : IDomainRule
{
    private readonly RegistrationStatus _status;

    internal RegistrationCannotBeExpiredMoreThanOnceDomainRule(RegistrationStatus status) => _status = status;

    public string Message => "This registration has already been marked as expired and cannot be expired again.";

    public bool IsBroken() => _status.Value.Equals(RegistrationStatus.Expired.Value);
}