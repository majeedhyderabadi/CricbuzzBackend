using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MatchApi.Domain.Entities;

namespace MatchApi.Infrastructure.Persistence.Configurations;

public class SportRoleConfiguration : IEntityTypeConfiguration<SportRole>
{
    private static readonly DateTime SeedCreatedAtUtc = new(2026, 7, 1, 0, 0, 0, DateTimeKind.Utc);
    public void Configure(EntityTypeBuilder<SportRole> builder)
    {
        builder.ToTable("SportRoles");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.RoleName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(r => r.Description)
            .HasMaxLength(250);

        builder.Property(r => r.SportId)
            .IsRequired();

        builder.HasOne(r => r.Sport)
            .WithMany(s => s.Roles)
            .HasForeignKey(r => r.SportId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Players)
            .WithOne(p => p.SportRole)
            .HasForeignKey(p => p.SportRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(r => new
        {
            r.SportId,
            r.RoleName
        }).IsUnique();

        // Optional Seed Data
        builder.HasData(

            // Cricket Roles
            new 
            {
                Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                SportId = new Guid("11111111-1111-1111-1111-111111111111"),
                RoleName = "Batter",
                CreatedAtUtc = SeedCreatedAtUtc,
                Description = "Description"
            },
            new 
            {
                Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                SportId = new Guid("11111111-1111-1111-1111-111111111111"),
                RoleName = "Bowler",
                CreatedAtUtc = SeedCreatedAtUtc,
                Description = "Description"
            },
            new 
            {
                Id = new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                SportId = new Guid("11111111-1111-1111-1111-111111111111"),
                RoleName = "All-rounder",
                CreatedAtUtc = SeedCreatedAtUtc,
                Description = "Description"
            },

            // Football Roles
            new 
            {
                Id = new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                SportId = new Guid("22222222-2222-2222-2222-222222222222"),
                RoleName = "Goalkeeper",
                CreatedAtUtc = SeedCreatedAtUtc,
                Description = "Description"
            },
            new 
            {
                Id = new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                SportId = new Guid("22222222-2222-2222-2222-222222222222"),
                RoleName = "Defender",
                CreatedAtUtc = SeedCreatedAtUtc,
                Description = "Description"
            },
            new 
            {
                Id = new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                SportId = new Guid("22222222-2222-2222-2222-222222222222"),
                RoleName = "Forward",
                CreatedAtUtc = SeedCreatedAtUtc,
                Description = "Description"
            }
        );
    }
}