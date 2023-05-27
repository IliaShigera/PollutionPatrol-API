namespace PollutionPatrol.Modules.Pollution.Application.Features.Vote.Down;

internal sealed class DownVoteReportCommandValidator : AbstractValidator<DownVoteReportCommand>
{
    public DownVoteReportCommandValidator()
    {
        RuleFor(command => command.ReportId)
            .NotEmpty()
            .WithMessage("Report id is required.");
    }
}