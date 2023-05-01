namespace PollutionPatrol.BuildingBlocks.Infrastructure;

public static class DependencyInjection
{
    public static void AddBuildingBlocks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssemblies(
            Assembly.Load("PollutionPatrol.BuildingBlocks.Application")));

        services.AddScoped<IDomainEventsAccessor, DomainEventsAccessor>();
        services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();
    }
}