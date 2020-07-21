using Microsoft.EntityFrameworkCore.Migrations;

namespace Capinfo.Migrations
{
    public partial class AuthorityModelUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "AbpAuthoritys");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AbpAuthoritys",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AbpAuthoritys");

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "AbpAuthoritys",
                type: "bit",
                nullable: true);
        }
    }
}
