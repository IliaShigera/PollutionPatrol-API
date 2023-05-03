namespace PollutionPatrol.Modules.UserAccess.Domain.Registration;

public interface IEmailValidator
{
    bool IsEmailUnique(string emailAddress);
    bool IsEmailConfirmationPending(string emailAddress);
}