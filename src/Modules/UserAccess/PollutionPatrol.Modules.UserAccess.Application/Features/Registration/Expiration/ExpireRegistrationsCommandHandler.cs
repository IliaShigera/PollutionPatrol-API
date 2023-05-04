namespace PollutionPatrol.Modules.UserAccess.Application.Features.Registration.Expiration;

internal sealed class ExpireRegistrationsCommandHandler : ICommandHandler<ExpireRegistrationsCommand>
{
    private readonly IUserAccessDbContext _dbContext;

    public ExpireRegistrationsCommandHandler(IUserAccessDbContext dbContext) => _dbContext = dbContext;

    public async Task Handle(ExpireRegistrationsCommand command, CancellationToken cancellationToken)
    {
        var expiredRegistrations = await _dbContext.Registrations
            .Where(r => r.Status.Value.Equals(RegistrationStatus.ConfirmationPending)
                        && r.ExpirationDate <= command.ExpirationDate)
            .ToListAsync(cancellationToken);

        expiredRegistrations.ForEach(registration => registration.Expire());

        _dbContext.Registrations.UpdateRange(expiredRegistrations);
        await _dbContext.CommitAsync(cancellationToken);
    }
}