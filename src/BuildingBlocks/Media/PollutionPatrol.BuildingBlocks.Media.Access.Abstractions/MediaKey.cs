namespace PollutionPatrol.BuildingBlocks.Media.Access.Abstractions;

public sealed class MediaKey
{
    public MediaKey(string value) => Value = value;

    public string Value { get; init; }

    #region Utilities

    private static bool EqualOperator(MediaKey left, MediaKey right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            return false;

        return ReferenceEquals(left, right) || left.Equals(right);
    }

    private static bool NotEqualOperator(MediaKey left, MediaKey right) => !EqualOperator(left, right);

    private IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
            return false;

        var other = (MediaKey)obj;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode() =>
        GetEqualityComponents()
            .Select(x => x.GetHashCode())
            .Aggregate((x, y) => x ^ y);

    public static bool operator ==(MediaKey one, MediaKey two) => EqualOperator(one, two);

    public static bool operator !=(MediaKey one, MediaKey two) => NotEqualOperator(one, two);

    #endregion
}