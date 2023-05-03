namespace PollutionPatrol.BuildingBlocks.Notification.Email;

public static class DependencyInjection
{
    public static void AddEmailNotifications(IServiceCollection services)
    {
        services.AddOptions<EmailOptions>()
            .BindConfiguration(EmailOptions.Section)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddScoped<INotificationSender<EmailNotificationMessage>, EmailNotificationSender>();
    }
}