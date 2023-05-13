namespace PollutionPatrol.BuildingBlocks.Media.Access;

public static class DependencyInjection
{
    public static void AddExternalMediaStorageAccess(this IServiceCollection services)
    {
        services.AddOptions<DropBoxOptions>()
            .BindConfiguration(DropBoxOptions.Section)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddTransient<IMediaStorageAccessProvider, MediaStorageAccessProvider>();
        services.AddTransient<IDropBoxStorageAccessor, DropBoxStorageAccessor>();
    }
}