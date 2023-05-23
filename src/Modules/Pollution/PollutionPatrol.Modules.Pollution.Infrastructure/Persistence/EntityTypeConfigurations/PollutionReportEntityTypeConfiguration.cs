namespace PollutionPatrol.Modules.Pollution.Infrastructure.Persistence.EntityTypeConfigurations;

internal sealed class PollutionReportEntityTypeConfiguration : IEntityTypeConfiguration<PollutionReport>
{
    public void Configure(EntityTypeBuilder<PollutionReport> builder)
    {
        builder.ToTable("Reports");

        builder.OwnsOne(report => report.Status, statusBuilder =>
        {
            statusBuilder.Property(s => s.Value)
                .HasColumnName("Status")
                .IsRequired();
        });

        builder.OwnsOne(report => report.PollutionType, pollutionTypeBuilder =>
        {
            pollutionTypeBuilder.Property(s => s.Value)
                .HasColumnName("PollutionType")
                .IsRequired();
        });

        builder.OwnsMany(report => report.MediaAttachmentKeys, attachmentKeyBuilder =>
        {
            attachmentKeyBuilder.Property(mediaKey => mediaKey.Value)
                .HasColumnName("AttachmentKey")
                .IsRequired();
        });


        builder.Property(r => r.ReporterId)
            .IsRequired();

        builder.Property(r => r.Description)
            .IsRequired();

        builder.Property(r => r.ReportedAt)
            .IsRequired();

        builder.Property(r => r.Coordinates)
            .HasColumnType("geography(Point, 4326)")
            .IsRequired();

        builder.HasIndex(r => r.Coordinates).HasMethod("gist");
    }
}