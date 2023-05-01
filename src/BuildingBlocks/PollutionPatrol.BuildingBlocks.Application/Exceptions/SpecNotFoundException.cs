namespace PollutionPatrol.BuildingBlocks.Application.Exceptions;

public class SpecNotFoundException : Exception
{
    public SpecNotFoundException(string specName, string identifier, string? message = default) : base(message)
    {
        SpecName = specName;
        Identifier = identifier;
    }

    public string SpecName { get; }
    public string Identifier { get; }

    public override string ToString() => $"Spec \'{SpecName}\' with identifier \'{Identifier}\' is not found: {Message}.";
}