namespace PollutionPatrol.Modules.Pollution.Domain.Report.Rules;

internal sealed class ReportCanBeApprovedOnlyOnceDomainRule : IDomainRule
{
    private readonly ReportStatus _status;

    internal ReportCanBeApprovedOnlyOnceDomainRule(ReportStatus status) => _status = status;

    public string Message => "The report has already been approved.";

    public bool IsBroken() => _status.Equals(ReportStatus.Approved);
}