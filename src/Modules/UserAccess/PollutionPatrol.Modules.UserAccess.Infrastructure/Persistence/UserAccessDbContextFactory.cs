namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence;

internal sealed class UserAccessDbContextFactory : IDesignTimeDbContextFactory<UserAccessDbContext>
{
    public UserAccessDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "API", "PollutionPatrol.API"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connection = config.GetConnectionString("UserAccess");

        var optionsBuilder = new DbContextOptionsBuilder<UserAccessDbContext>();
        optionsBuilder.UseSqlServer(connection);

        return new UserAccessDbContext(optionsBuilder.Options, eventsDispatcher: default);
    }
}