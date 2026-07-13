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
        }
    }
}
