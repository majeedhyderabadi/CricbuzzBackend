using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MatchApi.Domain.Entities;

namespace MatchApi.Infrastructure.Persistence.Configurations;

public class SportConfiguration : IEntityTypeConfiguration<Sport>
{
    private static readonly DateTime SeedCreatedAtUtc = new(2026, 7, 1, 0, 0, 0, DateTimeKind.Utc);
    public void Configure(EntityTypeBuilder<Sport> builder)
    {
        builder.ToTable("Sports");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(s => s.Name)
            .IsUnique();

        builder.HasMany(s => s.Teams)
            .WithOne(t => t.Sport)
            .HasForeignKey(t => t.SportId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Roles)
            .WithOne(r => r.Sport)
            .HasForeignKey(r => r.SportId)
            .OnDelete(DeleteBehavior.Cascade);

        // Optional Seed Data
        builder.HasData(
            new 
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                Name = "Cricket",
                CreatedAtUtc = SeedCreatedAtUtc,
                Description = "Description"
            },
            new 
            {
                Id = new Guid("22222222-2222-2222-2222-222222222222"),
                Name = "Football",
                CreatedAtUtc = SeedCreatedAtUtc,
                Description = "Description"
            }
        );
    }
}