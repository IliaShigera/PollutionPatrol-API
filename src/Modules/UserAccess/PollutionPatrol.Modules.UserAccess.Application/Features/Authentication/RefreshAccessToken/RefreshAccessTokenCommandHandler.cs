namespace PollutionPatrol.Modules.UserAccess.Application.Features.Authentication.RefreshAccessToken;

internal sealed class RefreshAccessTokenCommandHandler : ICommandHandler<RefreshAccessTokenCommand, AuthenticationDto>
{
    private readonly IUserAccessDbContext _dbContext;
    private readonly ITokenClaimsService _tokenClaimsService;

    public RefreshAccessTokenCommandHandler(IUserAccessDbContext dbContext, ITokenClaimsService tokenClaimsService)
    {
        _dbContext = dbContext;
        _tokenClaimsService = tokenClaimsService;
    }

    public async Task<AuthenticationDto> Handle(RefreshAccessTokenCommand command, CancellationToken cancellationToken)
    {
        var principal = _tokenClaimsService.ValidateExpiredToken(command.ExpiredAccessToken);
        var userId = _tokenClaimsService.GetUserIdFromPrincipal(principal);

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId), cancellationToken);
        if (user is null)
            throw new AuthenticationException(details: "User is not authenticated.");

        if (user.RefreshToken is null)
            throw new AuthenticationException(details: "User does not have a refresh token.");

        if (!user.RefreshToken.Value.Equals(command.RefreshToken))
            throw new AuthenticationException(details: "Invalid refresh token.");

        if (user.RefreshToken.ExpirationDate <= DateTime.UtcNow.Date)
            throw new AuthenticationException(details: "Refresh token has expired.");

        var newAccessToken = _tokenClaimsService.GenerateAccessToken(user);
        var newRefreshToken = _tokenClaimsService.GenerateRefreshToken();

        user.UpdateRefreshToken(newRefreshToken);
        _dbContext.Users.Update(user);
        await _dbContext.CommitAsync(cancellationToken);

        return new AuthenticationDto(newAccessToken, newRefreshToken.Value);
    }
}