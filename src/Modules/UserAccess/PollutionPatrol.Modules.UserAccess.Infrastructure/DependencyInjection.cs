namespace PollutionPatrol.Modules.UserAccess.Infrastructure;

public static class DependencyInjection
{
    public static void AddUserAccessModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<JwtOptions>()
            .BindConfiguration(JwtOptions.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var connection = configuration.GetConnectionString("UserAccess");

        services.AddDbContext<UserAccessDbContext>(options =>
            options.UseSqlServer(connection));

        services.AddMediatR(x => x.RegisterServicesFromAssemblies(
                Assembly.Load("PollutionPatrol.Modules.UserAccess.Application"),
                Assembly.Load("PollutionPatrol.Modules.UserAccess.Infrastructure"))
            .AddOpenBehavior(typeof(LoggingPipelineBehaviour<,>))
            .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>)));

        services.AddValidatorsFromAssembly(Assembly.Load("PollutionPatrol.Modules.UserAccess.Application"), includeInternalTypes: true);

        services.AddQuartz(q =>
        {
            q.SchedulerName = "UserAccess-Scheduler";
            q.UseMicrosoftDependencyInjectionJobFactory();

            q.ScheduleJob<ExpireRegistrationJob>(trigger => trigger
                .WithIdentity("ExpireRegistration-Job", "UserAccess-Group")
                .StartAt(DateTimeOffset.Now.AddSeconds(30))
                .WithCronSchedule("0 */4 * ? * *") // every 4th hour (0:00, 4:00, 8:00, 12:00, 16:00, 20:00).
                .WithDescription("Executes a command to expire registration records in the database based on a given expiration date.")
            );

            q.InterruptJobsOnShutdown = true;
            q.InterruptJobsOnShutdownWithWait = true;
        });

        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        services.AddTransient<ExpireRegistrationJob>();

        services.AddTransient<IUserAccessModule, UserAccessModule>();
        services.AddScoped<IUserAccessDbContext, UserAccessDbContext>();
        services.AddScoped<IEmailValidator, EmailValidator>();
        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddScoped<IConfirmationCodeGenerator, ConfirmationCodeGenerator>();
        services.AddScoped<ITokenClaimsService, TokenClaimsService>();
    }
}