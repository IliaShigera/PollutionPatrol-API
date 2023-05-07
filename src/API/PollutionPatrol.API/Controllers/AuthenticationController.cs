namespace PollutionPatrol.API.Controllers;

[ApiController]
[AllowAnonymous]
public sealed class AuthenticationController : ApiController
{
    private readonly IUserAccessModule _userAccessModule;

    public AuthenticationController(IUserAccessModule userAccessModule) => _userAccessModule = userAccessModule;

    [HttpPost("api/user/authenticate")]
    public async Task<IActionResult> AuthenticateUserAsync([FromBody] AuthenticationRequest request)
    {
        var authenticationDto = await _userAccessModule.ExecuteCommandAsync(new AuthenticateUserCommand(request.EmailAddress, request.Password));
        return Ok(authenticationDto);
    }
}