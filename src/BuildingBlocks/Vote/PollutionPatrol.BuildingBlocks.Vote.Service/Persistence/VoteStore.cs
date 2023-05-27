namespace PollutionPatrol.BuildingBlocks.Vote.Service.Persistence;

internal sealed class VoteStore : DbContext, IVoteStore
{
    public VoteStore(DbContextOptions<VoteStore> options) : base(options)
    {
    }

    public DbSet<Abstractions.Vote> Votes { get; private set; }

    public new async Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await base.SaveChangesAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new VoteEntityTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}