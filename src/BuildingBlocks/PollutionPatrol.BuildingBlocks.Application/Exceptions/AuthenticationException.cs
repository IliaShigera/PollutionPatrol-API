namespace PollutionPatrol.BuildingBlocks.Application.Exceptions;

public class AuthenticationException : Exception
{
    public AuthenticationException(string details, string? message = default) : this(message)
    {
        Details = details;
    }

    public AuthenticationException(string? message = default) : base(message)
    {
    }

    /// <summary>
    /// Gets the exception details for use in problem details.
    /// </summary>
    public string Details { get; }
    
    public override string ToString() => $"User is not authenticated: {Message}";
}