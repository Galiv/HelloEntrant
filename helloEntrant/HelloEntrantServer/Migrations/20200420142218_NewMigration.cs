using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloEntrantServer.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialities_Faculties_FacultyId",
                table: "Specialities");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "UniversityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialities_Faculties_FacultyId",
                table: "Specialities",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialities_Faculties_FacultyId",
                table: "Specialities");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialities_Faculties_FacultyId",
                table: "Specialities",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "FacultyId");
        }
    }
}
