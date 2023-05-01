namespace PollutionPatrol.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCurrentUserAccessor(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<ICurrentUserAccessor, CurrentUserAccessor>();
    }
}