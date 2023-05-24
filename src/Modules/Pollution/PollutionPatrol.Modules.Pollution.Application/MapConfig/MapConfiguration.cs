namespace PollutionPatrol.Modules.Pollution.Application.MapConfig;

internal static class MapConfiguration
{
    internal static void AddMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig<PollutionReport, PollutionReportDto>
            .NewConfig()
            .Map(dto => dto.Coordinates.Latitude, src => src.Coordinates.X)
            .Map(dto => dto.Coordinates.Longitude, src => src.Coordinates.Y)
            .Map(dto => dto.Status, src => src.Status.Value)
            .Map(dto => dto.PollutionType, src => src.PollutionType.Value)
            .Map(dto => dto.AttachmentKeys, src =>
                src.MediaAttachmentKeys
                    .Select(x => x.Value)
                    .ToList());

        TypeAdapterConfig<string, PollutionType>
            .NewConfig()
            .MapWith(src => GetPollutionType(src));
    }

    private static PollutionType? GetPollutionType(string pollutionType)
    {
        var pollutionTypes = typeof(PollutionType)
            .GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Where(p => p.PropertyType == typeof(PollutionType))
            .ToDictionary(p => p.Name, p => (PollutionType)p.GetValue(null));

        return pollutionTypes[pollutionType];
    }
}