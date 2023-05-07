namespace PollutionPatrol.Modules.UserAccess.Application.Features.Authentication;

internal sealed class AuthenticateUserCommandHandler : ICommandHandler<AuthenticateUserCommand, AuthenticationDto>
{
    private readonly IUserAccessDbContext _dbContext;
    private readonly IPasswordManager _passwordManager;
    private readonly ITokenClaimsService _tokenClaimsService;

    public AuthenticateUserCommandHandler(
        IUserAccessDbContext dbContext,
        IPasswordManager passwordManager,
        ITokenClaimsService tokenClaimsService)
    {
        _dbContext = dbContext;
        _passwordManager = passwordManager;
        _tokenClaimsService = tokenClaimsService;
    }

    public async Task<AuthenticationDto> Handle(AuthenticateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.EmailAddress.Equals(command.EmailAddress), cancellationToken);
        if (user is null)
            throw new AuthenticationException(details: "Authentication failed. The email you entered is incorrect. Please try again.");
        
        var isVerified = _passwordManager.VerifyPassword(command.Password, Convert.FromHexString(user.PasswordHash), Convert.FromHexString(user.Salt));
        if (isVerified is false)
            throw new AuthenticationException(details: "Authentication failed. The password you entered is incorrect. Please try again.");

        var accessToken = _tokenClaimsService.GenerateAccessToken(user);
        var refreshToken = _tokenClaimsService.GenerateRefreshToken();
        
        user.UpdateRefreshToken(refreshToken);
        
        _dbContext.Users.Update(user);
        await _dbContext.CommitAsync(cancellationToken);

        return new AuthenticationDto(accessToken, refreshToken.Value);
    }
}