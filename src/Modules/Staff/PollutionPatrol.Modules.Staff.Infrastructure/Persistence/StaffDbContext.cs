namespace PollutionPatrol.Modules.Staff.Infrastructure.Persistence;

internal sealed class StaffDbContext : DbContext, IStaffDbContext
{
    private readonly IDomainEventsDispatcher _eventsDispatcher;

    public StaffDbContext(DbContextOptions<StaffDbContext> options, IDomainEventsDispatcher eventsDispatcher)
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