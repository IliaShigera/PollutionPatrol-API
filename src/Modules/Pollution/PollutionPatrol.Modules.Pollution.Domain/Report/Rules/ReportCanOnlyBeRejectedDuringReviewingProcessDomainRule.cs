namespace PollutionPatrol.Modules.Pollution.Domain.Report.Rules;

internal sealed class ReportCanOnlyBeRejectedDuringReviewingProcessDomainRule : IDomainRule
{
    private readonly ReportStatus _status;

    internal ReportCanOnlyBeRejectedDuringReviewingProcessDomainRule(ReportStatus status) => _status = status;

    public string Message => "The report can only be rejected during the reviewing process";

    public bool IsBroken() => !_status.Equals(ReportStatus.Reviewing);
}