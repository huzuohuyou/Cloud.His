using Microsoft.EntityFrameworkCore.Migrations;

namespace Capinfo.Migrations
{
    public partial class add_filed_compmentName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComponentName",
                table: "AbpAuthoritys",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComponentName",
                table: "AbpAuthoritys");
        }
    }
}
