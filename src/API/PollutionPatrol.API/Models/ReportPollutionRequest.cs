namespace PollutionPatrol.API.Models;

public record ReportPollutionRequest(
    string Description,
    double Latitude,
    double Longitude,
    string PollutionType,
    IFormFileCollection Attachments);