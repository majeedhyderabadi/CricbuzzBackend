using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MatchApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedHyderabadAwayTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "ColorHex", "CreatedAtUtc", "Name", "Sport", "UpdatedAtUtc" },
                values: new object[] { new Guid("55555555-5555-5555-5555-555555555555"), "#F97316", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Hyderabad", "Cricket", null });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CreatedAtUtc", "Name", "Role", "TeamId", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-555555555551"), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Abhishek S", "Batter", new Guid("55555555-5555-5555-5555-555555555555"), null },
                    { new Guid("55555555-5555-5555-5555-555555555552"), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bhuvneshwar K", "Bowler", new Guid("55555555-5555-5555-5555-555555555555"), null },
                    { new Guid("55555555-5555-5555-5555-555555555553"), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Nitish R", "All-rounder", new Guid("55555555-5555-5555-5555-555555555555"), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555551"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555552"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555553"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));
        }
    }
}
