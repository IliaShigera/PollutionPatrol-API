namespace PollutionPatrol.Modules.Support.Infrastructure.Persistence;

internal sealed class SupportDbContext : DbContext, ISupportDbContext
{
    private readonly IDomainEventsDispatcher _eventsDispatcher;

    public SupportDbContext(DbContextOptions<SupportDbContext> options, IDomainEventsDispatcher eventsDispatcher)
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