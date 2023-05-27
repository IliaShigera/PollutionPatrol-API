namespace PollutionPatrol.BuildingBlocks.Vote.Service.Persistence;

internal sealed class VoteStoreDesignTimeFactory : IDesignTimeDbContextFactory<VoteStore>
{
    public VoteStore CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "API", "PollutionPatrol.API"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connection = config.GetConnectionString("Vote");

        var optionsBuilder = new DbContextOptionsBuilder<VoteStore>();
        optionsBuilder.UseSqlServer(connection);

        return new VoteStore(optionsBuilder.Options);
    }
}