namespace PollutionPatrol.API.Controllers;

[ApiController]
[AllowAnonymous]
public sealed class VoteController : ApiController
{
    private readonly ICurrentUserAccessor _currentUserAccessor;
    private readonly IVoteManager _voteManager;
    private readonly IVoteCounter _voteCounter;

    public VoteController(
        ICurrentUserAccessor currentUserAccessor,
        IVoteManager voteManager,
        IVoteCounter voteCounter)
    {
        _currentUserAccessor = currentUserAccessor;
        _voteManager = voteManager;
        _voteCounter = voteCounter;
    }
    
    [HttpPost("api/vote/up")]
    public async Task<IActionResult> UpVoteAsync([FromQuery] Guid itemId)
    {
        await _voteManager.UpVoteAsync(itemId, voterId: _currentUserAccessor.Id);
        return Ok();
    }

    [HttpPost("api/vote/down")]
    public async Task<IActionResult> DownVoteAsync([FromQuery] Guid itemId)
    {
        await _voteManager.DownVoteAsync(itemId, voterId: _currentUserAccessor.Id);
        return Ok();
    }

    [HttpDelete("api/vote/remove")]
    public async Task<IActionResult> RemoveVoteAsync([FromQuery] Guid itemId)
    {
        await _voteManager.RemoveVoteAsync(itemId, voterId: _currentUserAccessor.Id);
        return Ok();
    }

    [HttpGet("api/votes/count")]
    public async Task<IActionResult> VotesCountAsync([FromQuery] Guid itemId, [FromQuery] VoteType? voteType)
    {
        var votesCount = voteType switch
        {
            VoteType.Up => await _voteCounter.GetUpVotesAsync(itemId),
            VoteType.Down => await _voteCounter.GetDownVotesAsync(itemId),
            _ => await _voteCounter.GetTotalVotesAsync(itemId)
        };

        return Ok(new { VotesCount = votesCount });
    }
}