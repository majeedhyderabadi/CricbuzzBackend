using MatchApi.Domain.Entities;
using MatchApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MatchApi.Infrastructure.Persistence.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    private static readonly DateTime SeedCreatedAtUtc = new(2026, 7, 1, 0, 0, 0, DateTimeKind.Utc);

    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.ColorHex)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(t => t.SportId)
            .IsRequired();

        builder.HasOne(t => t.Sport)
            .WithMany(s => s.Teams)
            .HasForeignKey(t => t.SportId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(t => t.Players)
            .WithOne(p => p.Team)
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                Name = "NVian Strikers",
                SportId = new Guid("11111111-1111-1111-1111-111111111111"),
                ColorHex = "#8B5CF6",
                CreatedAtUtc = SeedCreatedAtUtc
            },
            new
            {
                Id = new Guid("22222222-2222-2222-2222-222222222222"),
                Name = "NVian FC",
                SportId = new Guid("22222222-2222-2222-2222-222222222222"),
                ColorHex = "#3B82F6",
                CreatedAtUtc = SeedCreatedAtUtc
            },
            new
            {
                Id = new Guid("55555555-5555-5555-5555-555555555555"),
                Name = "Hyderabad",
                SportId = new Guid("11111111-1111-1111-1111-111111111111"),
                ColorHex = "#F97316",
                CreatedAtUtc = SeedCreatedAtUtc
            });
    }
}
