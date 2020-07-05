using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capinfo.Migrations
{
    public partial class InitialAuthority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpAuthoritys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoudleName = table.Column<string>(nullable: true),
                    Father = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    MenuIcon = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ComponentName = table.Column<string>(nullable: true),
                    Component = table.Column<string>(nullable: true),
                    Permission = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuthoritys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpMouleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpMouleGroups", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpAuthoritys");

            migrationBuilder.DropTable(
                name: "AbpMouleGroups");
        }
    }
}
