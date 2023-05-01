namespace PollutionPatrol.Modules.Staff.Infrastructure.Persistence;

internal sealed class SupportDbContextFactory : IDesignTimeDbContextFactory<StaffDbContext>
{
    public StaffDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "API", "PollutionPatrol.API"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connection = config.GetConnectionString("Staff");

        var optionsBuilder = new DbContextOptionsBuilder<StaffDbContext>();
        optionsBuilder.UseSqlServer(connection);

        return new StaffDbContext(optionsBuilder.Options, eventsDispatcher: default);
    }
}