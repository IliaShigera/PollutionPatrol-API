namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Security;

internal sealed class PasswordManager : IPasswordManager
{
    private const int Length = 16;
    private const int Iterations = 10000;

    public byte[] HashPassword(string password, byte[] salt)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentNullException($"{nameof(password)}", "Password cannot be null");

        if (salt is null)
            throw new ArgumentNullException($"{nameof(salt)}", "Salt cannot be null");

        using Rfc2898DeriveBytes passwordHash = new(password, salt, Iterations, HashAlgorithmName.SHA512);
        return passwordHash.GetBytes(Length);
    }

    public bool VerifyPassword(string password, byte[] passwordHash, byte[] salt)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentNullException($"{nameof(password)}", "Password cannot be null or empty.");

        if (passwordHash is null)
            throw new ArgumentNullException($"{nameof(passwordHash)}", "Password hash cannot be null");

        if (salt is null)
            throw new ArgumentNullException($"{nameof(salt)}", "Salt cannot be null.");

        byte[] hash = HashPassword(password, salt);
        return hash.SequenceEqual(passwordHash);
    }

    public byte[] GenerateSalt()
    {
        var salt = new byte[Length];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);
        return salt;
    }
}