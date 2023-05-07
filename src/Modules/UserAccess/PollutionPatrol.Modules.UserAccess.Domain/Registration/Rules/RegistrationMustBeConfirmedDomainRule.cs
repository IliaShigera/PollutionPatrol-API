namespace PollutionPatrol.Modules.UserAccess.Domain.Registration.Rules;

internal sealed class RegistrationMustBeConfirmedDomainRule : IDomainRule
{
    private readonly RegistrationStatus _status;

    internal RegistrationMustBeConfirmedDomainRule(RegistrationStatus status) => _status = status;

    public string Message => "User cannot be created. Registration mush be confirmed.";
    
    public bool IsBroken() => !_status.Value.Equals(RegistrationStatus.Confirmed.Value);
}