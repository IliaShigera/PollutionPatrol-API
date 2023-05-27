namespace PollutionPatrol.Modules.Pollution.Application.Features.Vote.Up;

internal sealed class UpVoteReportCommandHandler : ICommandHandler<UpVoteReportCommand>
{
    private readonly IPollutionDbContext _dbContext;
    private readonly IVoteManager _voteManager;
    private readonly ICurrentUserAccessor _currentUserAccessor;

    public UpVoteReportCommandHandler(
        IPollutionDbContext dbContext,
        IVoteManager voteManager,
        ICurrentUserAccessor currentUserAccessor)
    {
        _dbContext = dbContext;
        _voteManager = voteManager;
        _currentUserAccessor = currentUserAccessor;
    }

    public async Task Handle(UpVoteReportCommand command, CancellationToken cancellationToken)
    {
        var report = await _dbContext.Reports.FirstOrDefaultAsync(r => r.Id.Equals(command.ReportId), cancellationToken);
        if (report is null)
            throw new SpecNotFoundException();

        await _voteManager.UpVoteAsync(itemId: report.Id, voterId: _currentUserAccessor.Id, cancellationToken);
    }
}