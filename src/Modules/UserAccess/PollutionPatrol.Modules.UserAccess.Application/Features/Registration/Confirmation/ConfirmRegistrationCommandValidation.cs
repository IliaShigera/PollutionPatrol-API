namespace PollutionPatrol.Modules.UserAccess.Application.Features.Registration.Confirmation;

internal sealed class ConfirmRegistrationCommandValidation : AbstractValidator<ConfirmRegistrationCommand>
{
    public ConfirmRegistrationCommandValidation()
    {
        RuleFor(x => x.ConfirmationCode)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Confirmation code is required.")
            .Matches("^[a-zA-Z0-9]+$")
            .WithMessage("Confirmation code must contain only letters and numbers.");
    }
}