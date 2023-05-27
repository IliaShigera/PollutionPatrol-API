namespace PollutionPatrol.API.Controllers;

[ApiController]
[Authorize]
public sealed class PollutionReportController : ApiController
{
    private readonly IPollutionModule _pollutionModule;

    public PollutionReportController(IPollutionModule pollutionModule) => _pollutionModule = pollutionModule;

    [HttpPost("api/pollution/report")]
    public async Task<ActionResult> ReportPollutionAsync([FromForm] ReportPollutionRequest request)
    {
        var reportDto = await _pollutionModule.ExecuteCommandAsync(
            new ReportPollutionCommand(
                request.Description,
                request.Latitude,
                request.Longitude,
                request.PollutionType,
                request.Attachments));

        return Ok(reportDto);
    }

    [HttpPost("api/pollution-reports/{reportId:guid}/votes/up")]
    public async Task<IActionResult> UpVoteReportAsync([FromRoute] Guid reportId)
    {
        await _pollutionModule.ExecuteCommandAsync(new UpVoteReportCommand(reportId));
        return Ok();
    }

    [HttpPost("api/pollution-reports/{reportId:guid}/votes/down")]
    public async Task<IActionResult> DownVoteReportAsync([FromRoute] Guid reportId)
    {
        await _pollutionModule.ExecuteCommandAsync(new DownVoteReportCommand(reportId));
        return Ok();
    }

    [HttpGet("api/pollution-reports/{reportId:guid}/votes/statistics")]
    public async Task<IActionResult> GetReportVotesAsync([FromRoute] Guid reportId)
    {
        var voteStatisticsDto = await _pollutionModule.ExecuteQueryAsync(new GetReportVoteStatisticsQuery(reportId));
        return Ok(voteStatisticsDto);
    }
}