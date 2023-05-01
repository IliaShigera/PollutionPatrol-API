namespace PollutionPatrol.Modules.Monitoring.Infrastructure.Persistence;

internal sealed class MonitoringDbContext : DbContext, IMonitoringDbContext
{
    private readonly IDomainEventsDispatcher _eventsDispatcher;

    public MonitoringDbContext(DbContextOptions<MonitoringDbContext> options, IDomainEventsDispatcher eventsDispatcher)
        : base(options)
    {
        _eventsDispatcher = eventsDispatcher;
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);

        await _eventsDispatcher.DispatchEventsAsync(this, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}