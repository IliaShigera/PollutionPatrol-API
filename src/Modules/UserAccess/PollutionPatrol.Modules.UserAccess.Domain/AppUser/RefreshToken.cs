namespace PollutionPatrol.Modules.UserAccess.Domain.AppUser;

public sealed class RefreshToken : ValueObject
{
    public RefreshToken(string value, DateTime creationDate, DateTime expirationDate)
    {
        Value = value;
        CreationDate = creationDate;
        ExpirationDate = expirationDate;
    }

    public string Value { get; init; }
    public DateTime CreationDate { get; init; }
    public DateTime ExpirationDate { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return CreationDate;
        yield return ExpirationDate;
    }
}