namespace PollutionPatrol.Modules.Pollution.Infrastructure.Persistence;

internal sealed class PollutionDbContext : DbContext, IPollutionDbContext
{
    private readonly IDomainEventsDispatcher _eventsDispatcher;

    public PollutionDbContext(DbContextOptions<PollutionDbContext> options, IDomainEventsDispatcher eventsDispatcher)
        : base(options)
    {
        _eventsDispatcher = eventsDispatcher;
    }

    public DbSet<PollutionReport> Reports { get; private set; }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);

        await _eventsDispatcher.DispatchEventsAsync(this, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PollutionReportEntityTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}