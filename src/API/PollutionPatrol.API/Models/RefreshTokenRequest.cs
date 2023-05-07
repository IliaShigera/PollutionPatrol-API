namespace PollutionPatrol.API.Models;

public record RefreshTokenRequest(string ExpiredToken, string RefreshToken);