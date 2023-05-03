namespace PollutionPatrol.BuildingBlocks.Notification.Email;

public static class DependencyInjection
{
    public static void AddEmailNotifications(this IServiceCollection services)
    {
        services.AddOptions<EmailOptions>()
            .BindConfiguration(EmailOptions.Section)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddScoped<IEmailNotificationSender, EmailNotificationSender>();
    }
}