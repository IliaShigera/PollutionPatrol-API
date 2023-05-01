namespace PollutionPatrol.Modules.Monitoring.Infrastructure;

public static class DependencyInjection
{
    public static void AddSupportModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Monitoring");

        services.AddDbContext<MonitoringDbContext>(options =>
            options.UseSqlServer(connection));

        services.AddMediatR(x => x.RegisterServicesFromAssemblies(
                Assembly.Load("PollutionPatrol.Modules.Monitoring.Application"),
                Assembly.Load("PollutionPatrol.Modules.Monitoring.Infrastructure"))
            .AddOpenBehavior(typeof(LoggingPipelineBehaviour<,>))
            .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>)));

        services.AddValidatorsFromAssembly(Assembly.Load("PollutionPatrol.Modules.Monitoring.Application"), includeInternalTypes: true);

        services.AddTransient<IMonitoringModule, MonitoringModule>();
        services.AddScoped<IMonitoringDbContext, MonitoringDbContext>();
    }
}