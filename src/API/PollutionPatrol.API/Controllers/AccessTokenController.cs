namespace PollutionPatrol.API.Controllers;

[ApiController]
[AllowAnonymous]
public sealed class AccessTokenController : ApiController
{
    private readonly IUserAccessModule _userAccessModule;

    public AccessTokenController(IUserAccessModule userAccessModule) => _userAccessModule = userAccessModule;

    [HttpPost("api/token/refresh")]
    public async Task<IActionResult> RefreshAccessTokenAsync([FromBody] RefreshTokenRequest request)
    {
        var authenticationDto = await _userAccessModule.ExecuteCommandAsync(new RefreshAccessTokenCommand(request.ExpiredToken, request.RefreshToken));
        return Ok(authenticationDto);
    }

    [HttpPost("api/token/revoke")]
    public async Task<IActionResult> RevokeRefreshToken()
    {
        await _userAccessModule.ExecuteCommandAsync(new RevokeRefreshTokenCommand());
        return Ok();
    }
}