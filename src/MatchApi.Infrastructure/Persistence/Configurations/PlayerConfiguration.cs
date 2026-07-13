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

        builder.Property(p => p.TeamId)
            .IsRequired();

        builder.Property(p => p.SportRoleId)
            .IsRequired();

        builder.HasOne(p => p.Team)
            .WithMany(t => t.Players)
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.SportRole)
            .WithMany(r => r.Players)
            .HasForeignKey(p => p.SportRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new
            {
                Id = new Guid("33333333-3333-3333-3333-333333333331"),
                Name = "Rohit Sharma",
                SportRoleId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                TeamId = new Guid("11111111-1111-1111-1111-111111111111"),
                CreatedAtUtc = SeedCreatedAtUtc
            },
            new
            {
                Id = new Guid("33333333-3333-3333-3333-333333333332"),
                Name = "Jasprit B",
                SportRoleId = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                TeamId = new Guid("11111111-1111-1111-1111-111111111111"),
                CreatedAtUtc = SeedCreatedAtUtc
            },
            new
            {
                Id = new Guid("33333333-3333-3333-3333-333333333333"),
                Name = "Hardik P",
                SportRoleId = new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                TeamId = new Guid("11111111-1111-1111-1111-111111111111"),
                CreatedAtUtc = SeedCreatedAtUtc
            },
            new
            {
                Id = new Guid("44444444-4444-4444-4444-444444444441"),
                Name = "Diallo",
                SportRoleId = new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                TeamId = new Guid("22222222-2222-2222-2222-222222222222"),
                CreatedAtUtc = SeedCreatedAtUtc
            },
            new
            {
                Id = new Guid("44444444-4444-4444-4444-444444444442"),
                Name = "Okafor",
                SportRoleId = new Guid("12121212-1212-1212-1212-121212121212"),
                TeamId = new Guid("22222222-2222-2222-2222-222222222222"),
                CreatedAtUtc = SeedCreatedAtUtc
            },
            new
            {
                Id = new Guid("55555555-5555-5555-5555-555555555551"),
                Name = "Abhishek S",
                SportRoleId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                TeamId = new Guid("22222222-2222-2222-2222-222222222222"),
                CreatedAtUtc = SeedCreatedAtUtc
            },
            new
            {
                Id = new Guid("55555555-5555-5555-5555-555555555552"),
                Name = "Bhuvneshwar K",
                SportRoleId = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                TeamId = new Guid("55555555-5555-5555-5555-555555555555"),
                CreatedAtUtc = SeedCreatedAtUtc
            },
            new
            {
                Id = new Guid("55555555-5555-5555-5555-555555555553"),
                Name = "Nitish R",
                SportRoleId = new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                TeamId = new Guid("55555555-5555-5555-5555-555555555555"),
                CreatedAtUtc = SeedCreatedAtUtc
            });
    }
}
