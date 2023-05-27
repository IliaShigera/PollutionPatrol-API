namespace PollutionPatrol.Modules.Pollution.Application.Features.Vote.Up;

public sealed record UpVoteReportCommand(Guid ReportId) : ICommand;