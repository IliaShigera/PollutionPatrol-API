namespace PollutionPatrol.Modules.UserAccess.Application.Features.Registration;

public sealed record RegisterNewUserCommand(string FirstName, string EmailAddress, string Password) : ICommand;