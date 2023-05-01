namespace PollutionPatrol.Modules.Organization.Infrastructure;

public static class DependencyInjection
{
    public static void AddSupportModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Organization");

        services.AddDbContext<OrganizationDbContext>(options =>
            options.UseSqlServer(connection));

        services.AddMediatR(x => x.RegisterServicesFromAssemblies(
                Assembly.Load("PollutionPatrol.Modules.Organization.Application"),
                Assembly.Load("PollutionPatrol.Modules.Organization.Infrastructure"))
            .AddOpenBehavior(typeof(LoggingPipelineBehaviour<,>))
            .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>)));

        services.AddValidatorsFromAssembly(Assembly.Load("PollutionPatrol.Modules.Organization.Application"), includeInternalTypes: true);

        services.AddTransient<IOrganizationModule, OrganizationModule>();
        services.AddScoped<IOrganizationDbContext, OrganizationDbContext>();
    }
}