namespace PollutionPatrol.Modules.UserAccess.Domain.Registration.Rules;

internal sealed class RegistrationCannotBeConfirmedMoreThanOnesDomainRule : IDomainRule
{
    private readonly RegistrationStatus _status;

    internal RegistrationCannotBeConfirmedMoreThanOnesDomainRule(RegistrationStatus status) => _status = status;

    public string Message => "Registration is already confirmed.";

    public bool IsBroken() => _status.Value.Equals(RegistrationStatus.Confirmed.Value);
}