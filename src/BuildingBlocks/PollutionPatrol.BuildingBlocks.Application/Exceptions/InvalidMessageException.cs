namespace PollutionPatrol.BuildingBlocks.Application.Exceptions;

public class InvalidMessageException : Exception
{
    public InvalidMessageException(IDictionary<string, string[]> errors, string? message = default) : base(message)
    {
        Errors = errors;
    }

    public IDictionary<string, string[]> Errors { get; }
}