namespace PollutionPatrol.BuildingBlocks.Application.Exceptions;

public class SpecNotFoundException : Exception
{
    public SpecNotFoundException(string? specName = default, string? message = default)
        : base(message)     
    {
        SpecName = specName;
    }

    public string? SpecName { get; }

    public override string ToString() => $"Spec \'{SpecName}\' is not found: {Message}.";
}