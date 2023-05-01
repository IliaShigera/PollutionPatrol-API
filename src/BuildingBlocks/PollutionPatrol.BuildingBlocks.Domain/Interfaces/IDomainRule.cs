namespace PollutionPatrol.BuildingBlocks.Domain.Interfaces;

public interface IDomainRule
{
    bool IsBroken();
    
    string Message { get; }
}