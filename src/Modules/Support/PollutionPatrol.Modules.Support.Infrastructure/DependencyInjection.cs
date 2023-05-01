namespace PollutionPatrol.Modules.Support.Infrastructure;

public static class DependencyInjection
{
    public static void AddSupportModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Support");

        services.AddDbContext<SupportDbContext>(options =>
            options.UseSqlServer(connection));

        services.AddMediatR(x => x.RegisterServicesFromAssemblies(
                Assembly.Load("PollutionPatrol.Modules.Support.Application"),
                Assembly.Load("PollutionPatrol.Modules.Support.Infrastructure"))
            .AddOpenBehavior(typeof(LoggingPipelineBehaviour<,>))
            .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>)));

        services.AddValidatorsFromAssembly(Assembly.Load("PollutionPatrol.Modules.Support.Application"), includeInternalTypes: true);

        services.AddTransient<ISupportModule, SupportModule>();
        services.AddScoped<ISupportDbContext, SupportDbContext>();
    }
}