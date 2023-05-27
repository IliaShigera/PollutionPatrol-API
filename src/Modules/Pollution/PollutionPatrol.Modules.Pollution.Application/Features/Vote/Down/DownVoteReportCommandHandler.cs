namespace PollutionPatrol.Modules.Pollution.Application.Features.Vote.Down;

internal sealed class DownVoteReportCommandHandler : ICommandHandler<DownVoteReportCommand>
{
    private readonly IPollutionDbContext _dbContext;
    private readonly IVoteManager _voteManager;
    private readonly ICurrentUserAccessor _currentUserAccessor;

    public DownVoteReportCommandHandler(
        IPollutionDbContext dbContext,
        IVoteManager voteManager,
        ICurrentUserAccessor currentUserAccessor)
    {
        _dbContext = dbContext;
        _voteManager = voteManager;
        _currentUserAccessor = currentUserAccessor;
    }

    public async Task Handle(DownVoteReportCommand command, CancellationToken cancellationToken)
    {
        var report = await _dbContext.Reports.FirstOrDefaultAsync(r => r.Id.Equals(command.ReportId), cancellationToken);
        if (report is null)
            throw new SpecNotFoundException();

        await _voteManager.DownVoteAsync(itemId: report.Id, voterId: _currentUserAccessor.Id, cancellationToken);
    }
}