using MatchApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchApi.Infrastructure.Persistence.Configurations;

public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.ToTable("Matches");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.HomeTeam)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.AwayTeam)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Venue)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(m => m.MatchDateUtc)
            .IsRequired();

        builder.Property(m => m.CreatedAtUtc)
            .IsRequired();
    }
}
