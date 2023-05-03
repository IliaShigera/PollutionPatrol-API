namespace PollutionPatrol.Modules.UserAccess.Application.Contracts;

public interface IUserAccessDbContext : IDbContext
{
    DbSet<UserRegistration> Registrations { get; }
    DbSet<ApplicationUser> Users { get; }
}