using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MatchApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminConsoleEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sport = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ColorHex = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomeTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AwayTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sport = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ScheduledAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HomeScore = table.Column<int>(type: "int", nullable: false),
                    HomeWickets = table.Column<int>(type: "int", nullable: true),
                    AwayScore = table.Column<int>(type: "int", nullable: false),
                    AwayWickets = table.Column<int>(type: "int", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fixtures_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fixtures_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentaryEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FixtureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Side = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentaryEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentaryEntries_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentaryEntries_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "ColorHex", "CreatedAtUtc", "Name", "Sport", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "#8B5CF6", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "NVian Strikers", "Cricket", null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "#3B82F6", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "NVian FC", "Football", null }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CreatedAtUtc", "Name", "Role", "TeamId", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333331"), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Rohit Sharma", "Batter", new Guid("11111111-1111-1111-1111-111111111111"), null },
                    { new Guid("33333333-3333-3333-3333-333333333332"), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Jasprit B", "Bowler", new Guid("11111111-1111-1111-1111-111111111111"), null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Hardik P", "All-rounder", new Guid("11111111-1111-1111-1111-111111111111"), null },
                    { new Guid("44444444-4444-4444-4444-444444444441"), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Diallo", "Forward", new Guid("22222222-2222-2222-2222-222222222222"), null },
                    { new Guid("44444444-4444-4444-4444-444444444442"), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Okafor", "Midfielder", new Guid("22222222-2222-2222-2222-222222222222"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentaryEntries_FixtureId",
                table: "CommentaryEntries",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentaryEntries_PlayerId",
                table: "CommentaryEntries",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_AwayTeamId",
                table: "Fixtures",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_HomeTeamId",
                table: "Fixtures",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentaryEntries");

            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
