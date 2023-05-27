namespace PollutionPatrol.Modules.Pollution.Application.Features.Vote.Up;

internal sealed class UpVoteReportCommandValidator : AbstractValidator<UpVoteReportCommand>
{
    public UpVoteReportCommandValidator()
    {
        RuleFor(command => command.ReportId)
            .NotEmpty()
            .WithMessage("Report id is required.");
    }
}