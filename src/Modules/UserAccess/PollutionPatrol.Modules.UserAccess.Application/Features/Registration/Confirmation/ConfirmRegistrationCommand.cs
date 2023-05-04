namespace PollutionPatrol.Modules.UserAccess.Application.Features.Registration.Confirmation;

public sealed record ConfirmRegistrationCommand(string ConfirmationCode) : ICommand;