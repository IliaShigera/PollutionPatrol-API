namespace PollutionPatrol.BuildingBlocks.Application.Interfaces;

/// <summary>
/// Marker
/// </summary>
public interface IPagedQuery
{
    int Page { get; }
    int Size { get; }
}