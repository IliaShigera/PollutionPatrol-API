namespace PollutionPatrol.Modules.UserAccess.Application.Features.Registration.Confirmation;

internal sealed class ConfirmRegistrationCommandHandler : ICommandHandler<ConfirmRegistrationCommand>
{
    private readonly IUserAccessDbContext _dbContext;

    public ConfirmRegistrationCommandHandler(IUserAccessDbContext dbContext) => _dbContext = dbContext;

    public async Task Handle(ConfirmRegistrationCommand command, CancellationToken cancellationToken)
    {
        var registration = await _dbContext.Registrations
            .FirstOrDefaultAsync(x => x.ConfirmationCode.Equals(command.ConfirmationCode), cancellationToken);

        if (registration is null)
            throw new SpecNotFoundException();

        registration.Confirm();

        _dbContext.Registrations.Update(registration);
        await _dbContext.CommitAsync(cancellationToken);
    }
}