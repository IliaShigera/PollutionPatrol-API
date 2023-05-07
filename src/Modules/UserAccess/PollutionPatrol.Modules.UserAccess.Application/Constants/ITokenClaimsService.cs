namespace PollutionPatrol.Modules.UserAccess.Application.Constants;

public interface ITokenClaimsService
{
    string GenerateAccessToken(ApplicationUser user);

    ClaimsPrincipal ValidateExpiredToken(string token);
    
    Guid GetUserIdFromPrincipal(ClaimsPrincipal principal);
    
    RefreshToken GenerateRefreshToken();
}