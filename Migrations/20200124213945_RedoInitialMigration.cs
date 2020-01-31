using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfHandicap.Migrations
{
    public partial class RedoInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreDifferenital",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "ScoreDiff",
                table: "Differentials");

            migrationBuilder.AddColumn<float>(
                name: "Differential",
                table: "Differentials",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Differential",
                table: "Differentials");

            migrationBuilder.AddColumn<float>(
                name: "ScoreDifferenital",
                table: "Rounds",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ScoreDiff",
                table: "Differentials",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
