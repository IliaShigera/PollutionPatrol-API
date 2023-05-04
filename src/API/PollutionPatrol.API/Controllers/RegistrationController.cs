namespace PollutionPatrol.API.Controllers;

[ApiController]
[AllowAnonymous]
public sealed class RegistrationController : ApiController
{
    private readonly IUserAccessModule _userAccessModule;

    public RegistrationController(IUserAccessModule userAccessModule) => _userAccessModule = userAccessModule;

    [HttpPost("api/registration")]
    public async Task<ActionResult> RegisterNewUserAsync([FromBody] RegistrationRequest request)
    {
        await _userAccessModule.ExecuteCommandAsync(new RegisterNewUserCommand(request.FirstName, request.Email, request.Password));
        return Ok();
    }
    
    [HttpPatch("api/registration/confirm")]
    public async Task<ActionResult> ConfirmRegistrationAsync([FromQuery] string confirmationCode)
    {
        await _userAccessModule.ExecuteCommandAsync(new ConfirmRegistrationCommand(confirmationCode));
        return Ok();
    }
}