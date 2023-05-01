namespace PollutionPatrol.Modules.Admin.Infrastructure;

public static class DependencyInjection
{
    public static void AddSupportModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Admin");

        services.AddDbContext<AdminDbContext>(options =>
            options.UseSqlServer(connection));

        services.AddMediatR(x => x.RegisterServicesFromAssemblies(
                Assembly.Load("PollutionPatrol.Modules.Admin.Application"),
                Assembly.Load("PollutionPatrol.Modules.Admin.Infrastructure"))
            .AddOpenBehavior(typeof(LoggingPipelineBehaviour<,>))
            .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>)));

        services.AddValidatorsFromAssembly(Assembly.Load("PollutionPatrol.Modules.Admin.Application"), includeInternalTypes: true);

        services.AddTransient<IAdminModule, AdminModule>();
        services.AddScoped<IAdminDbContext, AdminDbContext>();
    }
}