namespace PollutionPatrol.Modules.UserAccess.Application.Constants;

public interface ITokenClaimsService
{
    string GenerateToken(ApplicationUser user);
}