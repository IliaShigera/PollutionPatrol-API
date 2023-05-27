namespace PollutionPatrol.Modules.Pollution.Application.Features.Vote.Stats;

public sealed record GetReportVoteStatisticsQuery(Guid ReportId) : IQuery<ReportVoteStatisticsDto>;