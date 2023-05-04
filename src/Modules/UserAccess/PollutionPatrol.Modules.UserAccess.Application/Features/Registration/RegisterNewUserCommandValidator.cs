namespace PollutionPatrol.Modules.UserAccess.Application.Features.Registration;

internal sealed class RegisterNewUserCommandValidator : AbstractValidator<RegisterNewUserCommand>
{
    public RegisterNewUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.");

        RuleFor(x => x.EmailAddress)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Email address is required.")
            .EmailAddress()
            .WithMessage("Email address must be a valid email.");

        RuleFor(x => x.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(PasswordRequirements.MinimumPasswordLength)
            .WithMessage($"Password must be at least {PasswordRequirements.MinimumPasswordLength} characters long.");
    }
}