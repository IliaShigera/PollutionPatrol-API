namespace PollutionPatrol.Modules.Support.Infrastructure.Persistence;

internal sealed class SupportDbContextFactory : IDesignTimeDbContextFactory<SupportDbContext>
{
    public SupportDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "API", "PollutionPatrol.API"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connection = config.GetConnectionString("Support");

        var optionsBuilder = new DbContextOptionsBuilder<SupportDbContext>();
        optionsBuilder.UseSqlServer(connection);

        return new SupportDbContext(optionsBuilder.Options, eventsDispatcher: default);
    }
}