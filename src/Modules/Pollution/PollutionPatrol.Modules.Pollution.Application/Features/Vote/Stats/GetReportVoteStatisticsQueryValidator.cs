namespace PollutionPatrol.Modules.Pollution.Application.Features.Vote.Stats;

internal sealed class GetReportVoteStatisticsQueryValidator : AbstractValidator<GetReportVoteStatisticsQuery>
{
    public GetReportVoteStatisticsQueryValidator()
    {
        RuleFor(query => query.ReportId)
            .NotEmpty()
            .WithMessage("Report id is required.");
    }
}