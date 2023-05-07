namespace PollutionPatrol.Modules.UserAccess.Application.Features.Authentication.RevokeRefreshToken;

internal sealed class RevokeRefreshTokenCommandHandler : ICommandHandler<RevokeRefreshTokenCommand>
{
    private readonly IUserAccessDbContext _dbContext;
    private readonly ICurrentUserAccessor _currentUserAccessor;

    public RevokeRefreshTokenCommandHandler(IUserAccessDbContext dbContext, ICurrentUserAccessor currentUserAccessor)
    {
        _dbContext = dbContext;
        _currentUserAccessor = currentUserAccessor;
    }

    public async Task Handle(RevokeRefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var userId = _currentUserAccessor.Id;
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId), cancellationToken);

        if (user is null)
            throw new AuthenticationException(details: "User is not authenticated.");

        user.UpdateRefreshToken(null);
        _dbContext.Users.Update(user);
        await _dbContext.CommitAsync(cancellationToken);
    }
}