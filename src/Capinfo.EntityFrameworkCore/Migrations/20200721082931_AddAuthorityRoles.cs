using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capinfo.Migrations
{
    public partial class AddAuthorityRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AbpAuthoritys");

            migrationBuilder.CreateTable(
                name: "AbpAuthorityRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false),
                    AuthorityId = table.Column<long>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuthorityRoles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpAuthorityRoles");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AbpAuthoritys",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
