namespace PollutionPatrol.Modules.Pollution.Domain.Report;

public sealed class PollutionType : ValueObject
{
    private PollutionType(string value) => Value = value;
    
    public string Value { get; init; }

    public static PollutionType Soil => new(nameof(Soil));
    public static PollutionType Watter => new(nameof(Watter));
    public static PollutionType Air => new(nameof(Air));
    public static PollutionType Plastic => new(nameof(Plastic));
    public static PollutionType Microplastic => new(nameof(Microplastic));
    public static PollutionType Noise => new(nameof(Noise));
    public static PollutionType Visual => new(nameof(Visual));
    public static PollutionType Industrial => new(nameof(Industrial));
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}