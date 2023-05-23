namespace PollutionPatrol.Modules.Pollution.Domain.Report;

public sealed class ReportStatus : ValueObject
{
    private ReportStatus(string value) => Value = value;

    public string Value { get; init; }

    public static ReportStatus Pending => new(nameof(Pending));
    public static ReportStatus Reviewing => new(nameof(Reviewing));
    public static ReportStatus Approved => new(nameof(Approved));
    public static ReportStatus Rejected => new(nameof(Rejected));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}