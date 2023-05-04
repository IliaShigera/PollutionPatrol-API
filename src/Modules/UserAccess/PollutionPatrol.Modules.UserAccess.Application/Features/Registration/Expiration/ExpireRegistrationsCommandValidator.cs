namespace PollutionPatrol.Modules.UserAccess.Application.Features.Registration.Expiration;

internal sealed class ExpireRegistrationsCommandValidator : AbstractValidator<ExpireRegistrationsCommand>
{
    public ExpireRegistrationsCommandValidator()
    {
        RuleFor(x => x.ExpirationDate)
            .NotEmpty()
            .WithMessage("Expiration date is required.");
    }
}