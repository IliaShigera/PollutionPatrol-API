namespace PollutionPatrol.Modules.Pollution.Application.Features.Report;

internal sealed class ReportPollutionCommandHandler : ICommandHandler<ReportPollutionCommand, PollutionReportDto>
{
    private readonly IPollutionDbContext _dbContext;
    private readonly ICurrentUserAccessor _currentUserAccessor;
    private readonly IMediaStorageAccessProvider _mediaStorageAccessProvider;

    public ReportPollutionCommandHandler(
        IPollutionDbContext dbContext,
        ICurrentUserAccessor currentUserAccessor,
        IMediaStorageAccessProvider mediaStorageAccessProvider)
    {
        _dbContext = dbContext;
        _currentUserAccessor = currentUserAccessor;
        _mediaStorageAccessProvider = mediaStorageAccessProvider;
    }

    public async Task<PollutionReportDto> Handle(ReportPollutionCommand command, CancellationToken cancellationToken)
    {
        var attachmentKeys = await UploadAttachmentsAsync(command.Attachments);
        var reporterId = _currentUserAccessor.Id;
        var coordinates = new Point(command.Latitude, command.Longitude);
        var pollutionType = command.PollutionType.Adapt<PollutionType>();

        var report = PollutionReport.Create(
            reporterId,
            command.Description,
            coordinates,
            pollutionType,
            attachmentKeys);

        await _dbContext.Reports.AddAsync(report, cancellationToken);
        await _dbContext.CommitAsync(cancellationToken);

        return report.Adapt<PollutionReportDto>();
    }

    private async Task<IReadOnlyList<MediaKey>> UploadAttachmentsAsync(IFormFileCollection attachments)
    {
        var mediaAttachmentKeys = new List<MediaKey>();
        foreach (var attachment in attachments)
        {
            await using var stream = attachment.OpenReadStream();
            var mediaKey = await _mediaStorageAccessProvider.DropBox.UploadMediaAsync(stream, attachment.FileName);
            mediaAttachmentKeys.Add(mediaKey);
        }

        return mediaAttachmentKeys.AsReadOnly();
    }
}