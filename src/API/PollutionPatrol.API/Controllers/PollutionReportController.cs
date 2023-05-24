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
}