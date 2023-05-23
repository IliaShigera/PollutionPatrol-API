namespace PollutionPatrol.Modules.Pollution.Domain.Report.Rules;

internal sealed class ReportCanBeRejectedOnlyOnceDomainRule : IDomainRule
{
    private readonly ReportStatus _status;

    internal ReportCanBeRejectedOnlyOnceDomainRule(ReportStatus status) => _status = status;

    public string Message => "The report has already been rejected.";

    public bool IsBroken() => _status.Equals(ReportStatus.Rejected);
}