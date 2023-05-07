namespace PollutionPatrol.Modules.UserAccess.Application.Features.Authentication.RefreshAccessToken;

public sealed record RefreshAccessTokenCommand(string ExpiredAccessToken, string RefreshToken) : ICommand<AuthenticationDto>;