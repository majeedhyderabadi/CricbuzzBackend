using MatchApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchApi.Infrastructure.Persistence.Configurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    private static readonly DateTime SeedCreatedAtUtc = new(2026, 7, 1, 0, 0, 0, DateTimeKind.Utc);

    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.ToTable("Players");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Role)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasData(
            new
            {
                Id = new Guid("33333333-3333-3333-3333-333333333331"),
                Name = "Rohit Sharma",
                Role = "Batter",
                TeamId = TeamConfiguration.NVianStrikersId,
                CreatedAtUtc = SeedCreatedAtUtc,
                UpdatedAtUtc = (DateTime?)null
            },
            new
            {
                Id = new Guid("33333333-3333-3333-3333-333333333332"),
                Name = "Jasprit B",
                Role = "Bowler",
                TeamId = TeamConfiguration.NVianStrikersId,
                CreatedAtUtc = SeedCreatedAtUtc,
                UpdatedAtUtc = (DateTime?)null
            },
            new
            {
                Id = new Guid("33333333-3333-3333-3333-333333333333"),
                Name = "Hardik P",
                Role = "All-rounder",
                TeamId = TeamConfiguration.NVianStrikersId,
                CreatedAtUtc = SeedCreatedAtUtc,
                UpdatedAtUtc = (DateTime?)null
            },
            new
            {
                Id = new Guid("44444444-4444-4444-4444-444444444441"),
                Name = "Diallo",
                Role = "Forward",
                TeamId = TeamConfiguration.NVianFcId,
                CreatedAtUtc = SeedCreatedAtUtc,
                UpdatedAtUtc = (DateTime?)null
            },
            new
            {
                Id = new Guid("44444444-4444-4444-4444-444444444442"),
                Name = "Okafor",
                Role = "Midfielder",
                TeamId = TeamConfiguration.NVianFcId,
                CreatedAtUtc = SeedCreatedAtUtc,
                UpdatedAtUtc = (DateTime?)null
            },
            new
            {
                Id = new Guid("55555555-5555-5555-5555-555555555551"),
                Name = "Abhishek S",
                Role = "Batter",
                TeamId = TeamConfiguration.HyderabadId,
                CreatedAtUtc = SeedCreatedAtUtc,
                UpdatedAtUtc = (DateTime?)null
            },
            new
            {
                Id = new Guid("55555555-5555-5555-5555-555555555552"),
                Name = "Bhuvneshwar K",
                Role = "Bowler",
                TeamId = TeamConfiguration.HyderabadId,
                CreatedAtUtc = SeedCreatedAtUtc,
                UpdatedAtUtc = (DateTime?)null
            },
            new
            {
                Id = new Guid("55555555-5555-5555-5555-555555555553"),
                Name = "Nitish R",
                Role = "All-rounder",
                TeamId = TeamConfiguration.HyderabadId,
                CreatedAtUtc = SeedCreatedAtUtc,
                UpdatedAtUtc = (DateTime?)null
            });
    }
}
