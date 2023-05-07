namespace PollutionPatrol.Modules.UserAccess.Application.Features.Authentication;

public sealed record AuthenticateUserCommand(string EmailAddress, string Password) : ICommand<AuthenticationDto>;