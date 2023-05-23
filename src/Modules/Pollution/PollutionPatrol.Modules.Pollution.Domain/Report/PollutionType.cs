namespace PollutionPatrol.Modules.Pollution.Domain.Report;

public sealed class PollutionType : ValueObject
{
    private PollutionType(string value) => Value = value;
    
    public string Value { get; init; }

    public PollutionType Soil => new(nameof(Soil));
    public PollutionType Watter => new(nameof(Watter));
    public PollutionType Air => new(nameof(Air));
    public PollutionType Plastic => new(nameof(Plastic));
    public PollutionType Microplastic => new(nameof(Microplastic));
    public PollutionType Noise => new(nameof(Noise));
    public PollutionType Visual => new(nameof(Visual));
    public PollutionType Industrial => new(nameof(Industrial));
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}