using AuthenticationException = PollutionPatrol.BuildingBlocks.Application.Exceptions.AuthenticationException;

namespace PollutionPatrol.API.CurrentUserAccess;

internal sealed class CurrentUserAccessor : ICurrentUserAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserAccessor(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;

    public Guid Id
    {
        get
        {
            var idString = _httpContextAccessor.HttpContext?.User.FindFirst(CustomClaimTypes.UserId)?.Value;

            if (string.IsNullOrWhiteSpace(idString))
                throw new AuthenticationException();

            Guid.TryParse(idString, out Guid id);

            return id;
        }
    }
}