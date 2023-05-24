namespace PollutionPatrol.Modules.Pollution.Application.Features.Report;

public sealed class ReportPollutionCommand : ICommand<PollutionReportDto>
{
    public ReportPollutionCommand(
        string description,
        double latitude,
        double longitude,
        string pollutionType,
        IFormFileCollection attachments)
    {
        Description = description;
        Latitude = latitude;
        Longitude = longitude;
        PollutionType = pollutionType;
        Attachments = attachments;
    }

    public string Description { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public string PollutionType { get; init; }
    public IFormFileCollection Attachments { get; init; }
}