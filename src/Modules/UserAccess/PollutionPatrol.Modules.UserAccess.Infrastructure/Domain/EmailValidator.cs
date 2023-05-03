namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Domain;

internal sealed class EmailValidator : IEmailValidator
{
    private readonly IUserAccessDbContext _dbContext;

    public EmailValidator(IUserAccessDbContext dbContext) => _dbContext = dbContext;

    public bool IsEmailUnique(string emailAddress) => !_dbContext.Users.Any(u => u.EmailAddress.Equals(emailAddress));

    public bool IsEmailConfirmationPending(string emailAddress) => _dbContext.Registrations
        .Any(r => r.EmailAddress.Equals(emailAddress) && r.Status.Value.Equals(RegistrationStatus.ConfirmationPending.Value));
}