namespace PollutionPatrol.BuildingBlocks.Application.Interfaces;

public interface ICurrentUserAccessor
{
    Guid Id { get; }
}