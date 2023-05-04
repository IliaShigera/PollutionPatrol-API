namespace PollutionPatrol.Modules.UserAccess.Application.Features.Registration;

internal sealed class RegisterNewUserCommandHandler : ICommandHandler<RegisterNewUserCommand>
{
    private readonly IUserAccessDbContext _dbContext;
    private readonly IEmailValidator _emailValidator;
    private readonly IPasswordManager _passwordManager;
    private readonly IConfirmationCodeGenerator _confirmationCodeGenerator;

    public RegisterNewUserCommandHandler(
        IUserAccessDbContext dbContext,
        IEmailValidator emailValidator,
        IPasswordManager passwordManager,
        IConfirmationCodeGenerator confirmationCodeGenerator)
    {
        _dbContext = dbContext;
        _emailValidator = emailValidator;
        _passwordManager = passwordManager;
        _confirmationCodeGenerator = confirmationCodeGenerator;
    }

    public async Task Handle(RegisterNewUserCommand command, CancellationToken cancellationToken)
    {
        var salt = _passwordManager.GenerateSalt();
        var passwordHash = _passwordManager.HashPassword(command.Password, salt);
        var confirmationCode = _confirmationCodeGenerator.GenerateConfirmationCode();
        var expirationDate = DateTime.UtcNow.Date.AddDays(UserRegistrationExpiration.MaximumDaysForRegistration);

        var registration = UserRegistration.Create(
            command.FirstName,
            command.EmailAddress,
            _emailValidator,
            passwordHash: Convert.ToHexString(passwordHash),
            salt: Convert.ToHexString(salt),
            confirmationCode,
            expirationDate);

        await _dbContext.Registrations.AddAsync(registration, cancellationToken);
        await _dbContext.CommitAsync(cancellationToken);
    }
}