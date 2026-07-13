using MatchApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchApi.Infrastructure.Persistence.Configurations;

public class CommentaryEntryConfiguration : IEntityTypeConfiguration<CommentaryEntry>
{
    public void Configure(EntityTypeBuilder<CommentaryEntry> builder)
    {
        builder.ToTable("CommentaryEntries");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Side)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(c => c.Action)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(30);

        builder.Property(c => c.Note)
            .HasMaxLength(500);

        builder.HasOne(c => c.Fixture)
            .WithMany(f => f.CommentaryEntries)
            .HasForeignKey(c => c.FixtureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Player)
            .WithMany()
            .HasForeignKey(c => c.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
