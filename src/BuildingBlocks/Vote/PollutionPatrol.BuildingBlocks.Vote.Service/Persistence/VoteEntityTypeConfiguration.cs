namespace PollutionPatrol.BuildingBlocks.Vote.Service.Persistence;

internal sealed class VoteEntityTypeConfiguration : IEntityTypeConfiguration<Abstractions.Vote>
{
    public void Configure(EntityTypeBuilder<Abstractions.Vote> builder)
    {
        builder.ToTable("Votes");

        builder.Property(v => v.ItemId).IsRequired();
        builder.Property(v => v.VoterId).IsRequired();
        builder.Property(v => v.VoteType).IsRequired();
    }
}