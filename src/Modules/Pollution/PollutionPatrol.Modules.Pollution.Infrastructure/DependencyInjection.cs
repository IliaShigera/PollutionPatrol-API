﻿namespace PollutionPatrol.Modules.Pollution.Infrastructure;

public static class DependencyInjection
{
    public static void AddSupportModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Pollution");

        services.AddDbContext<PollutionDbContext>(options =>
            options.UseSqlServer(connection));

        services.AddMediatR(x => x.RegisterServicesFromAssemblies(
                Assembly.Load("PollutionPatrol.Modules.Pollution.Application"),
                Assembly.Load("PollutionPatrol.Modules.Pollution.Infrastructure"))
            .AddOpenBehavior(typeof(LoggingPipelineBehaviour<,>))
            .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>)));

        services.AddValidatorsFromAssembly(Assembly.Load("PollutionPatrol.Modules.Pollution.Application"), includeInternalTypes: true);

        services.AddTransient<IPollutionModule, PollutionModule>();
        services.AddScoped<IPollutionDbContext, PollutionDbContext>();
    }
}