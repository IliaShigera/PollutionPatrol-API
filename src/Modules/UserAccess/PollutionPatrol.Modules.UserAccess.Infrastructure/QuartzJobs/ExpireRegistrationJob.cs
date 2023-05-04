namespace PollutionPatrol.Modules.UserAccess.Infrastructure.QuartzJobs;

internal sealed class ExpireRegistrationJob : IJob
{
    private readonly IUserAccessModule _userAccessModule;
    private readonly ILogger _logger;

    public ExpireRegistrationJob(IUserAccessModule userAccessModule, ILogger logger)
    {
        _userAccessModule = userAccessModule;
        _logger = logger;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var expirationDate = DateTime.UtcNow.Date;

        try
        {
            _logger.Information($"{nameof(ExpireRegistrationJob)} executing. Expiration date: {expirationDate}");

            await _userAccessModule.ExecuteCommandAsync(new ExpireRegistrationsCommand(expirationDate));

            _logger.Information($"{nameof(ExpireRegistrationJob)} executed successfully");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "An error occurred while executing ExpireRegistrationJob");
        }
    }
}