namespace PollutionPatrol.Modules.Staff.Infrastructure;

public static class DependencyInjection
{
    public static void AddSupportModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Staff");

        services.AddDbContext<StaffDbContext>(options =>
            options.UseSqlServer(connection));

        services.AddMediatR(x => x.RegisterServicesFromAssemblies(
                Assembly.Load("PollutionPatrol.Modules.Staff.Application"),
                Assembly.Load("PollutionPatrol.Modules.Staff.Infrastructure"))
            .AddOpenBehavior(typeof(LoggingPipelineBehaviour<,>))
            .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>)));

        services.AddValidatorsFromAssembly(Assembly.Load("PollutionPatrol.Modules.Staff.Application"), includeInternalTypes: true);

        services.AddTransient<IStaffModule, StaffModule>();
        services.AddScoped<IStaffDbContext, StaffDbContext>();
    }
}