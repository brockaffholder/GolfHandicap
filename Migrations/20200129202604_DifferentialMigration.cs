using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfHandicap.Migrations
{
    public partial class DifferentialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Differentials_DifferentialID",
                table: "Rounds");

            migrationBuilder.DropTable(
                name: "Differentials");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_DifferentialID",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "DifferentialID",
                table: "Rounds");

            migrationBuilder.AddColumn<float>(
                name: "ScoreDifferential",
                table: "Rounds",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreDifferential",
                table: "Rounds");

            migrationBuilder.AddColumn<int>(
                name: "DifferentialID",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Differentials",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Differential = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Differentials", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_DifferentialID",
                table: "Rounds",
                column: "DifferentialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Differentials_DifferentialID",
                table: "Rounds",
                column: "DifferentialID",
                principalTable: "Differentials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
