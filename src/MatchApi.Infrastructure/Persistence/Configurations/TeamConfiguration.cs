using MatchApi.Domain.Entities;
using MatchApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchApi.Infrastructure.Persistence.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public static readonly Guid NVianStrikersId = new("11111111-1111-1111-1111-111111111111");
    public static readonly Guid NVianFcId = new("22222222-2222-2222-2222-222222222222");
    public static readonly Guid HyderabadId = new("55555555-5555-5555-5555-555555555555");

    private static readonly DateTime SeedCreatedAtUtc = new(2026, 7, 1, 0, 0, 0, DateTimeKind.Utc);

    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Sport)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(t => t.ColorHex)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasMany(t => t.Players)
            .WithOne(p => p.Team)
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new
            {
                Id = NVianStrikersId,
                Name = "NVian Strikers",
                Sport = Sport.Cricket,
                ColorHex = "#8B5CF6",
                CreatedAtUtc = SeedCreatedAtUtc,
                UpdatedAtUtc = (DateTime?)null
            },
            new
            {
                Id = NVianFcId,
                Name = "NVian FC",
                Sport = Sport.Football,
                ColorHex = "#3B82F6",
                CreatedAtUtc = SeedCreatedAtUtc,
                UpdatedAtUtc = (DateTime?)null
            },
            new
            {
                Id = HyderabadId,
                Name = "Hyderabad",
                Sport = Sport.Cricket,
                ColorHex = "#F97316",
                CreatedAtUtc = SeedCreatedAtUtc,
                UpdatedAtUtc = (DateTime?)null
            });
    }
}
