namespace PollutionPatrol.Modules.Organization.Infrastructure.Persistence;

internal sealed class OrganizationDbContextFactory : IDesignTimeDbContextFactory<OrganizationDbContext>
{
    public OrganizationDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "API", "PollutionPatrol.API"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connection = config.GetConnectionString("Organization");

        var optionsBuilder = new DbContextOptionsBuilder<OrganizationDbContext>();
        optionsBuilder.UseSqlServer(connection);

        return new OrganizationDbContext(optionsBuilder.Options, eventsDispatcher: default);
    }
}