using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloEntrantServer.Migrations
{
    public partial class NewMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Users_UserId",
                table: "Universities");

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Users_UserId",
                table: "Universities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Users_UserId",
                table: "Universities");

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Users_UserId",
                table: "Universities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
