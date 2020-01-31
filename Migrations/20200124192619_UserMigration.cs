using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfHandicap.Migrations
{
    public partial class UserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "RoundID",
                table: "Rounds");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Rounds",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Rounds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Users_UserID",
                table: "Rounds");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_UserID",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Rounds");

            migrationBuilder.AddColumn<int>(
                name: "RoundID",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds",
                column: "RoundID");
        }
    }
}
