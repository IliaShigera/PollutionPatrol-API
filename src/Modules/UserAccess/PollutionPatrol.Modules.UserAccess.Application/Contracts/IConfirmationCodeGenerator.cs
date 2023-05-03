namespace PollutionPatrol.Modules.UserAccess.Application.Contracts;

public interface IConfirmationCodeGenerator
{
    string GenerateConfirmationCode();
}