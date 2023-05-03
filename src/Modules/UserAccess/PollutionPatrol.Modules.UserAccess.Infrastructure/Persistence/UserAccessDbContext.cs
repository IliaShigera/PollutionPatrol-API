namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence;

internal sealed class UserAccessDbContext : DbContext, IUserAccessDbContext
{
    private readonly IDomainEventsDispatcher _eventsDispatcher;

    public UserAccessDbContext(DbContextOptions<UserAccessDbContext> options, IDomainEventsDispatcher eventsDispatcher)
        : base(options)
    {
        _eventsDispatcher = eventsDispatcher;
    }

    public DbSet<UserRegistration> Registrations { get; private set; }
    public DbSet<ApplicationUser> Users { get; private set; }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);

        await _eventsDispatcher.DispatchEventsAsync(this, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserRegistrationEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationUserEntityTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}