namespace PollutionPatrol.Modules.Pollution.Application.Features.Vote.Stats;

internal sealed class GetReportVoteStatisticsQueryHandler : IQueryHandler<GetReportVoteStatisticsQuery, ReportVoteStatisticsDto>
{
    private readonly IPollutionDbContext _dbContext;
    private readonly IVoteCounter _voteCounter;

    public GetReportVoteStatisticsQueryHandler(IPollutionDbContext dbContext, IVoteCounter voteCounter)
    {
        _dbContext = dbContext;
        _voteCounter = voteCounter;
    }

    public async Task<ReportVoteStatisticsDto> Handle(GetReportVoteStatisticsQuery query, CancellationToken cancellationToken)
    {
        var report = await _dbContext.Reports.FirstOrDefaultAsync(r => r.Id.Equals(query.ReportId), cancellationToken);
        if (report is null)
            throw new SpecNotFoundException();

        var upVotes = await _voteCounter.GetUpVotesAsync(itemId: report.Id, cancellationToken);
        var downVotes = await _voteCounter.GetDownVotesAsync(itemId: report.Id, cancellationToken);
        var total = upVotes + downVotes;

        return new ReportVoteStatisticsDto(upVotes, downVotes, total);
    }
}