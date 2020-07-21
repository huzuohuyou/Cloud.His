using Microsoft.EntityFrameworkCore.Migrations;

namespace Capinfo.Migrations
{
    public partial class AuthorityModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Component",
                table: "AbpAuthoritys");

            migrationBuilder.DropColumn(
                name: "Continer",
                table: "AbpAuthoritys");

            migrationBuilder.DropColumn(
                name: "MenuType",
                table: "AbpAuthoritys");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "AbpAuthoritys");

            migrationBuilder.DropColumn(
                name: "Root",
                table: "AbpAuthoritys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Component",
                table: "AbpAuthoritys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Continer",
                table: "AbpAuthoritys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuType",
                table: "AbpAuthoritys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "AbpAuthoritys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Root",
                table: "AbpAuthoritys",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
