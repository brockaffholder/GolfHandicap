using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfHandicap.Migrations
{
    public partial class DifferentialUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Users_UserID",
                table: "Rounds");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_UserID",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Rounds");

            migrationBuilder.AddColumn<int>(
                name: "DifferentialID",
                table: "Rounds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ScoreDifferenital",
                table: "Rounds",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Differentials",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoreDiff = table.Column<float>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ScoreDifferenital",
                table: "Rounds");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_UserID",
                table: "Rounds",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Users_UserID",
                table: "Rounds",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
