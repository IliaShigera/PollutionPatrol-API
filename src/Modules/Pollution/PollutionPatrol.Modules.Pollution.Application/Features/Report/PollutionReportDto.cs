namespace PollutionPatrol.Modules.Pollution.Application.Features.Report;

public record PollutionReportDto(
    Guid Id,
    string Description,
    CoordinatesDto Coordinates,
    DateTime ReportedAt,
    string Status,
    string PollutionType,
    List<string> AttachmentKeys);