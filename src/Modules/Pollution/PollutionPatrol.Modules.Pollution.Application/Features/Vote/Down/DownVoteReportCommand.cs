namespace PollutionPatrol.Modules.Pollution.Application.Features.Vote.Down;

public sealed record DownVoteReportCommand(Guid ReportId) : ICommand;