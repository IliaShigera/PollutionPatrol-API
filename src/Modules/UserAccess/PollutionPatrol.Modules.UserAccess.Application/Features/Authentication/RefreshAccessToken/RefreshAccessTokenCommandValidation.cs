namespace PollutionPatrol.Modules.UserAccess.Application.Features.Authentication.RefreshAccessToken;

internal sealed class RefreshAccessTokenCommandValidation : AbstractValidator<RefreshAccessTokenCommand>
{
    public RefreshAccessTokenCommandValidation()
    {
        RuleFor(x => x.ExpiredAccessToken)
            .NotEmpty()
            .WithMessage("Expired access token is required.");
        
        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithMessage("Refresh token is required.");
    }
}