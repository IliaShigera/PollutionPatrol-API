namespace PollutionPatrol.BuildingBlocks.Vote.Service;

public static class DependencyInjection
{
    public static void AddVoteService(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Vote");

        services.AddDbContext<VoteStore>(options =>
            options.UseSqlServer(connection));

        services.AddScoped<IVoteStore, VoteStore>();
        services.AddScoped<IVoteCounter, VoteCounter>();
        services.AddScoped<IVoteManager, VoteManager>();
    }
}