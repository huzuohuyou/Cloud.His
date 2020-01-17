using Microsoft.EntityFrameworkCore.Migrations;

namespace Capinfo.Migrations
{
    public partial class Add_Questions2_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "USER",
                table: "Question",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "TYPE",
                table: "Question",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "ROLE",
                table: "Question",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "REASON",
                table: "Question",
                newName: "Reason");

            migrationBuilder.RenameColumn(
                name: "QUESTION",
                table: "Question",
                newName: "Question");

            migrationBuilder.RenameColumn(
                name: "PTNO",
                table: "Question",
                newName: "Ptno");

            migrationBuilder.RenameColumn(
                name: "PHONE",
                table: "Question",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "KIND",
                table: "Question",
                newName: "Kind");

            migrationBuilder.RenameColumn(
                name: "DEPT",
                table: "Question",
                newName: "Dept");

            migrationBuilder.RenameColumn(
                name: "DATE",
                table: "Question",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ANSWER",
                table: "Question",
                newName: "Answer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Question",
                newName: "USER");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Question",
                newName: "TYPE");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Question",
                newName: "ROLE");

            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "Question",
                newName: "REASON");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Question",
                newName: "QUESTION");

            migrationBuilder.RenameColumn(
                name: "Ptno",
                table: "Question",
                newName: "PTNO");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Question",
                newName: "PHONE");

            migrationBuilder.RenameColumn(
                name: "Kind",
                table: "Question",
                newName: "KIND");

            migrationBuilder.RenameColumn(
                name: "Dept",
                table: "Question",
                newName: "DEPT");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Question",
                newName: "DATE");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "Question",
                newName: "ANSWER");
        }
    }
}
