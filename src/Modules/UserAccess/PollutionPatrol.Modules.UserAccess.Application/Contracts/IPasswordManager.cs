namespace PollutionPatrol.Modules.UserAccess.Application.Contracts;

public interface IPasswordManager
{
    byte[] HashPassword(string password, byte[] salt);

    bool VerifyPassword(string password, byte[] passwordHash, byte[] salt);

    byte[] GenerateSalt();
}