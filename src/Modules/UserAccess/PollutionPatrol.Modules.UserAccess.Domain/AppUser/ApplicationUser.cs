namespace PollutionPatrol.Modules.UserAccess.Domain.AppUser;

public sealed class ApplicationUser : Entity
{
    public ApplicationUser(
        string firstName,
        string emailAddress,
        string passwordHash,
        string salt,
        List<UserRole> roles)
    {
        FirstName = firstName;
        EmailAddress = emailAddress;
        PasswordHash = passwordHash;
        Salt = salt;
        Roles = roles;
    }

    private ApplicationUser()
    {
        // EF only
    }

    public string FirstName { get; private set; }
    public string EmailAddress { get; private set; }
    public string PasswordHash { get; private set; }
    public string Salt { get; private set; }
    public RefreshToken? RefreshToken { get; private set; }
    public List<UserRole> Roles { get; private set; }

    internal static ApplicationUser CreateFromRegistration(UserRegistration registration)
    {
        return new ApplicationUser(
            registration.FirstName,
            registration.EmailAddress,
            registration.PasswordHash,
            registration.Salt,
            roles: new List<UserRole> { UserRole.User });
    }

    public static ApplicationUser CreateAdmin(string firstName, string emailAddress, string passwordHash, string salt)
    {
        return new ApplicationUser(
            firstName,
            emailAddress,
            passwordHash,
            salt,
            roles: new List<UserRole> { UserRole.Admin });
    }

    public void UpdateRefreshToken(RefreshToken? refreshToken) => RefreshToken = refreshToken;
}