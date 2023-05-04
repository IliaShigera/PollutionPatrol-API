namespace PollutionPatrol.Modules.UserAccess.Application.Features.Registration.Expiration;

public sealed record ExpireRegistrationsCommand(DateTime ExpirationDate) : ICommand;