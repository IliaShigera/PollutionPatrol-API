namespace PollutionPatrol.Modules.Pollution.Application.Features.Report;

internal sealed class ReportPollutionCommandValidator : AbstractValidator<ReportPollutionCommand>
{
    public ReportPollutionCommandValidator()
    {
        RuleFor(command => command.Description)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters.");

        RuleFor(command => command.Latitude)
            .InclusiveBetween(-90, 90)
            .WithMessage("Latitude must be between -90 and 90.");

        RuleFor(command => command.Longitude)
            .InclusiveBetween(-180, 180)
            .WithMessage("Longitude must be between -180 and 180.");

        RuleFor(command => command.PollutionType)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("At least one pollution type must be specified.")
            .Must(IsValidPollutionType)
            .WithMessage("Pollution type is not defined.");

        RuleFor(command => command.Attachments)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Media attachments are required.")
            .ForEach(attachment =>
                attachment.Must(IsValidAttachmentExtension)
                    .WithMessage("Attachment format is not supporting."));
    }

    private bool IsValidAttachmentExtension(IFormFile file)
    {
        var allowedExtensions = new[] { ".heic", ".heif", ".jpg", ".jpeg", ".png", ".dng", ".raw", ".mp4", ".mov" };
        var fileExtension = Path.GetExtension(file.FileName).ToLower();
        return allowedExtensions.Contains(fileExtension);
    }

    private bool IsValidPollutionType(string pollutionType)
    {
        var pollutionTypes = typeof(PollutionType)
            .GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Where(p => p.PropertyType == typeof(PollutionType))
            .ToDictionary(p => p.Name, p => (PollutionType)p.GetValue(null));

        return pollutionTypes.ContainsKey(pollutionType);
    }
}