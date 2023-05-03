namespace PollutionPatrol.Modules.UserAccess.Domain.Registration.Rules;

internal sealed class UserEmailMushBeUniqueDomainRule : IDomainRule
{
    private readonly string _emailAddress;
    private readonly IEmailValidator _emailValidator;

    internal UserEmailMushBeUniqueDomainRule(string emailAddress, IEmailValidator emailValidator)
    {
        _emailAddress = emailAddress;
        _emailValidator = emailValidator;
    }

    public string Message { get; private set; }

    public bool IsBroken()
    {
        if (!_emailValidator.IsEmailUnique(_emailAddress))
        {
            Message = "Sorry, this email has already been registered. Please try again with a different email address.";

            return true;
        }

        if (_emailValidator.IsEmailConfirmationPending(_emailAddress))
        {
            Message = "This email address is pending verification. Please check your inbox for a confirmation email.";

            return true;
        }

        return false;
    }
}