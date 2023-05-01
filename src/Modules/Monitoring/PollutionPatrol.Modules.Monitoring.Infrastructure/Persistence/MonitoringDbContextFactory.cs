namespace PollutionPatrol.Modules.Monitoring.Infrastructure.Persistence;

internal sealed class MonitoringDbContextFactory : IDesignTimeDbContextFactory<MonitoringDbContext>
{
    public MonitoringDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "API", "PollutionPatrol.API"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connection = config.GetConnectionString("Monitoring");

        var optionsBuilder = new DbContextOptionsBuilder<MonitoringDbContext>();
        optionsBuilder.UseSqlServer(connection);

        return new MonitoringDbContext(optionsBuilder.Options, eventsDispatcher: default);
    }
}