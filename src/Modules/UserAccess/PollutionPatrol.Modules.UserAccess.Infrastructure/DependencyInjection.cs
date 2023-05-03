namespace PollutionPatrol.Modules.UserAccess.Infrastructure;

public static class DependencyInjection
{
    public static void AddUserAccessModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("UserAccess");

        services.AddDbContext<UserAccessDbContext>(options =>
            options.UseSqlServer(connection));

        services.AddMediatR(x => x.RegisterServicesFromAssemblies(
                Assembly.Load("PollutionPatrol.Modules.UserAccess.Application"),
                Assembly.Load("PollutionPatrol.Modules.UserAccess.Infrastructure"))
            .AddOpenBehavior(typeof(LoggingPipelineBehaviour<,>))
            .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>)));

        services.AddValidatorsFromAssembly(Assembly.Load("PollutionPatrol.Modules.UserAccess.Application"), includeInternalTypes: true);

        services.AddTransient<IUserAccessModule, UserAccessModule>();
        services.AddScoped<IUserAccessDbContext, UserAccessDbContext>();
        services.AddScoped<IEmailValidator, EmailValidator>();
        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddScoped<IConfirmationCodeGenerator, ConfirmationCodeGenerator>();
    }
}