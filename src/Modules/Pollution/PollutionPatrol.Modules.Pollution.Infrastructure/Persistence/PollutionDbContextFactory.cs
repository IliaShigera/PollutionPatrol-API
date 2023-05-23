namespace PollutionPatrol.Modules.Pollution.Infrastructure.Persistence;

internal sealed class PollutionDbContextFactory : IDesignTimeDbContextFactory<PollutionDbContext>
{
    public PollutionDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "API", "PollutionPatrol.API"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connection = config.GetConnectionString("Pollution");

        var optionsBuilder = new DbContextOptionsBuilder<PollutionDbContext>();
        optionsBuilder.UseNpgsql(connection, x => x.UseNetTopologySuite());

        return new PollutionDbContext(optionsBuilder.Options, eventsDispatcher: default);
    }
}