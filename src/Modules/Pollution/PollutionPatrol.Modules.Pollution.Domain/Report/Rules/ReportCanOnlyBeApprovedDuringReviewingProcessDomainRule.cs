namespace PollutionPatrol.Modules.Pollution.Domain.Report.Rules;

internal sealed class ReportCanOnlyBeApprovedDuringReviewingProcessDomainRule : IDomainRule
{
    private readonly ReportStatus _status;

    internal ReportCanOnlyBeApprovedDuringReviewingProcessDomainRule(ReportStatus status) => _status = status;

    public string Message => "The report can only be approved during the reviewing process";

    public bool IsBroken() => !_status.Equals(ReportStatus.Reviewing);
}