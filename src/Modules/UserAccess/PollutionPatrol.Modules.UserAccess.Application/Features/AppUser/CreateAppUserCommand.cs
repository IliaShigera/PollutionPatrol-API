namespace PollutionPatrol.Modules.UserAccess.Application.Features.AppUser;

internal sealed class CreateAppUserCommand : IDomainEventHandler<UserRegistrationConfirmedDomainEvent>
{
    private readonly IUserAccessDbContext _dbContext;

    public CreateAppUserCommand(IUserAccessDbContext dbContext) => _dbContext = dbContext;

    public async Task Handle(UserRegistrationConfirmedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        var appUser = domainEvent.Registration.CreateUser();

        await _dbContext.Users.AddAsync(appUser, cancellationToken);
        await _dbContext.CommitAsync(cancellationToken);
    }
}