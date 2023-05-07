namespace PollutionPatrol.Modules.UserAccess.Application.Features.Authentication;

public sealed record AuthenticationDto(string AccessToken, string RefreshToken);