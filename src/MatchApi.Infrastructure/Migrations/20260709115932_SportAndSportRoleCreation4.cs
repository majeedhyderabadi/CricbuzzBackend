using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SportAndSportRoleCreation4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Name", "Description", "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Cricket", "Description", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Football", "Description", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sports_Name",
                table: "Sports",
                column: "Name",
                unique: true);

            migrationBuilder.CreateTable(
                name: "SportRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportRoles_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SportRoles",
                columns: new[] { "Id", "SportId", "RoleName", "Description", "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("11111111-1111-1111-1111-111111111111"), "Batter", "Description", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("11111111-1111-1111-1111-111111111111"), "Bowler", "Description", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("11111111-1111-1111-1111-111111111111"), "All-rounder", "Description", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new Guid("22222222-2222-2222-2222-222222222222"), "Goalkeeper", "Description", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new Guid("22222222-2222-2222-2222-222222222222"), "Defender", "Description", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new Guid("22222222-2222-2222-2222-222222222222"), "Forward", "Description", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("12121212-1212-1212-1212-121212121212"), new Guid("22222222-2222-2222-2222-222222222222"), "Midfielder", "Description", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportRoles_SportId_RoleName",
                table: "SportRoles",
                columns: new[] { "SportId", "RoleName" },
                unique: true);

            // --- Teams: Sport (enum text) -> SportId (FK) ---
            migrationBuilder.AddColumn<Guid>(
                name: "SportId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.Empty);

            migrationBuilder.Sql(@"
                UPDATE Teams SET SportId = '11111111-1111-1111-1111-111111111111' WHERE Sport = 'Cricket';
                UPDATE Teams SET SportId = '22222222-2222-2222-2222-222222222222' WHERE Sport = 'Football';
            ");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SportId",
                table: "Teams",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Sports_SportId",
                table: "Teams",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.DropColumn(
                name: "Sport",
                table: "Teams");

            // --- Players: Role (free text) -> SportRoleId (FK) ---
            migrationBuilder.AddColumn<Guid>(
                name: "SportRoleId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.Empty);

            migrationBuilder.Sql(@"
                UPDATE p
                SET p.SportRoleId = sr.Id
                FROM Players p
                INNER JOIN Teams t ON t.Id = p.TeamId
                INNER JOIN SportRoles sr ON sr.SportId = t.SportId AND sr.RoleName = p.Role;
            ");

            migrationBuilder.CreateIndex(
                name: "IX_Players_SportRoleId",
                table: "Players",
                column: "SportRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_SportRoles_SportRoleId",
                table: "Players",
                column: "SportRoleId",
                principalTable: "SportRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Players");

            // --- Fixtures: Sport (enum text) -> SportId (FK) ---
            migrationBuilder.AddColumn<Guid>(
                name: "SportId",
                table: "Fixtures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.Empty);

            migrationBuilder.Sql(@"
                UPDATE Fixtures SET SportId = '11111111-1111-1111-1111-111111111111' WHERE Sport = 'Cricket';
                UPDATE Fixtures SET SportId = '22222222-2222-2222-2222-222222222222' WHERE Sport = 'Football';
            ");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_SportId",
                table: "Fixtures",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Sports_SportId",
                table: "Fixtures",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.DropColumn(
                name: "Sport",
                table: "Fixtures");

            migrationBuilder.UpdateData(
                table: "SportRoles",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Description" });

            migrationBuilder.UpdateData(
                table: "SportRoles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Description" });

            migrationBuilder.UpdateData(
                table: "SportRoles",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Description" });

            migrationBuilder.UpdateData(
                table: "SportRoles",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Description" });

            migrationBuilder.UpdateData(
                table: "SportRoles",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Description" });

            migrationBuilder.UpdateData(
                table: "SportRoles",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Description" });

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Description" });

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Description" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SportRoles",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 9, 11, 51, 11, 613, DateTimeKind.Utc).AddTicks(6251), "" });

            migrationBuilder.UpdateData(
                table: "SportRoles",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 9, 11, 51, 11, 613, DateTimeKind.Utc).AddTicks(6970), "" });

            migrationBuilder.UpdateData(
                table: "SportRoles",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 9, 11, 51, 11, 613, DateTimeKind.Utc).AddTicks(6973), "" });

            migrationBuilder.UpdateData(
                table: "SportRoles",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 9, 11, 51, 11, 613, DateTimeKind.Utc).AddTicks(6976), "" });

            migrationBuilder.UpdateData(
                table: "SportRoles",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 9, 11, 51, 11, 613, DateTimeKind.Utc).AddTicks(6990), "" });

            migrationBuilder.UpdateData(
                table: "SportRoles",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 9, 11, 51, 11, 613, DateTimeKind.Utc).AddTicks(6992), "" });

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 9, 11, 51, 11, 611, DateTimeKind.Utc).AddTicks(4242), "" });

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAtUtc", "Description" },
                values: new object[] { new DateTime(2026, 7, 9, 11, 51, 11, 611, DateTimeKind.Utc).AddTicks(4923), "" });

            // --- Fixtures: SportId (FK) -> Sport (enum text) ---
            migrationBuilder.AddColumn<string>(
                name: "Sport",
                table: "Fixtures",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(@"
                UPDATE f
                SET f.Sport = s.Name
                FROM Fixtures f
                INNER JOIN Sports s ON s.Id = f.SportId;
            ");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Sports_SportId",
                table: "Fixtures");

            migrationBuilder.DropIndex(
                name: "IX_Fixtures_SportId",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Fixtures");

            // --- Players: SportRoleId (FK) -> Role (free text) ---
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Players",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(@"
                UPDATE p
                SET p.Role = sr.RoleName
                FROM Players p
                INNER JOIN SportRoles sr ON sr.Id = p.SportRoleId;
            ");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_SportRoles_SportRoleId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_SportRoleId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SportRoleId",
                table: "Players");

            // --- Teams: SportId (FK) -> Sport (enum text) ---
            migrationBuilder.AddColumn<string>(
                name: "Sport",
                table: "Teams",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(@"
                UPDATE t
                SET t.Sport = s.Name
                FROM Teams t
                INNER JOIN Sports s ON s.Id = t.SportId;
            ");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Sports_SportId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_SportId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "SportRoles");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
