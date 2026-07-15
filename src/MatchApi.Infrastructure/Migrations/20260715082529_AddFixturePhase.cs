using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFixturePhase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phase",
                table: "Fixtures",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phase",
                table: "Fixtures");
        }
    }
}
