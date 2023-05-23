namespace PollutionPatrol.Modules.Pollution.Domain.Report;

public sealed class PollutionReport : Entity
{
    private PollutionReport(
        Guid reporterId,
        string description,
        Point coordinates,
        PollutionType pollutionType,
        IReadOnlyList<MediaKey> mediaAttachmentKeys)
    {
        ReporterId = reporterId;
        Description = description;
        Coordinates = coordinates;
        ReportedAt = DateTime.UtcNow;
        Status = ReportStatus.Pending;
        PollutionType = pollutionType;
        MediaAttachmentKeys = mediaAttachmentKeys;
    }

    private PollutionReport()
    {
        // EF only
    }

    public Guid ReporterId { get; init; }
    public string Description { get; init; }
    public Point Coordinates { get; init; }
    public DateTime ReportedAt { get; init; }
    public ReportStatus Status { get; private set; }
    public PollutionType PollutionType { get; init; }
    public IReadOnlyList<MediaKey> MediaAttachmentKeys { get; init; }


    public static PollutionReport Create(
        Guid reporterId,
        string description,
        Point coordinates,
        PollutionType pollutionType,
        IReadOnlyList<MediaKey> mediaAttachmentKeys)
    {
        return new PollutionReport(reporterId, description, coordinates, pollutionType, mediaAttachmentKeys);
    }

    public void Approve()
    {
        CheckRule(new ReportCanOnlyBeApprovedDuringReviewingProcessDomainRule(Status));
        CheckRule(new ReportCanBeApprovedOnlyOnceDomainRule(Status));

        Status = ReportStatus.Approved;
    }

    public void Reject()
    {
        CheckRule(new ReportCanOnlyBeRejectedDuringReviewingProcessDomainRule(Status));
        CheckRule(new ReportCanBeRejectedOnlyOnceDomainRule(Status));

        Status = ReportStatus.Rejected;
    }
}