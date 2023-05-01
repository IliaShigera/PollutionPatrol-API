namespace PollutionPatrol.BuildingBlocks.Domain.Exceptions;

public class DomainRuleBrokenException : Exception
{
    public DomainRuleBrokenException(IDomainRule brokenRule) : base(brokenRule.Message)
    {
        BrokenRule = brokenRule;
        Details = brokenRule.Message;
    }
    
    public IDomainRule BrokenRule { get; }

    /// <summary>
    /// Gets the exception details for use in problem details.
    /// </summary>
    public string Details { get; }

    /// <summary>
    /// Returns a string that represents the current DomainRuleBrokenException.
    /// </summary>
    /// <returns>A string that represents the current DomainRuleBrokenException.</returns>
    public override string ToString() => $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
}