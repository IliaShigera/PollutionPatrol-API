namespace PollutionPatrol.Modules.UserAccess.Domain.AppUser;

public sealed class UserRole : ValueObject
{
    public UserRole(string value) => Value = value;

    public string Value { get; init; }

    public static UserRole User => new(nameof(User));
    public static UserRole Admin => new(nameof(Admin));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}