namespace PollutionPatrol.Modules.UserAccess.Domain.Registration;

public sealed class RegistrationStatus : ValueObject
{
    private RegistrationStatus(string value) => Value = value;

    public string Value { get; init; }

    public static RegistrationStatus ConfirmationPending => new(nameof(ConfirmationPending));
    public static RegistrationStatus Confirmed => new(nameof(Confirmed));
    public static RegistrationStatus Expired => new(nameof(Expired));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}