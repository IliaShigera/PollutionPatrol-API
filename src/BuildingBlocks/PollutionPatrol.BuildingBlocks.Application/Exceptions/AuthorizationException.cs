namespace PollutionPatrol.BuildingBlocks.Application.Exceptions;

public class AuthorizationException : Exception
{
    public AuthorizationException(string? message = default) : base(message)
    {
    }

    public override string ToString() => $"User is not authorized: {Message}.";
}