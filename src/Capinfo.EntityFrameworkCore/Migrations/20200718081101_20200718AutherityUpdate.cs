using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capinfo.Migrations
{
    public partial class _20200718AutherityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpMouleGroups");

            migrationBuilder.DropColumn(
                name: "Component",
                table: "AbpAuthoritys");

            migrationBuilder.DropColumn(
                name: "ComponentName",
                table: "AbpAuthoritys");

            migrationBuilder.DropColumn(
                name: "MenuIcon",
                table: "AbpAuthoritys");

            migrationBuilder.DropColumn(
                name: "MoudleName",
                table: "AbpAuthoritys");

            migrationBuilder.DropColumn(
                name: "Permission",
                table: "AbpAuthoritys");

            migrationBuilder.AlterColumn<long>(
                name: "Father",
                table: "AbpAuthoritys",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "AbpAuthoritys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuType",
                table: "AbpAuthoritys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "AbpAuthoritys",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "AbpAuthoritys");

            migrationBuilder.DropColumn(
                name: "MenuType",
                table: "AbpAuthoritys");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AbpAuthoritys");

            migrationBuilder.AlterColumn<int>(
                name: "Father",
                table: "AbpAuthoritys",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Component",
                table: "AbpAuthoritys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComponentName",
                table: "AbpAuthoritys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuIcon",
                table: "AbpAuthoritys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoudleName",
                table: "AbpAuthoritys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Permission",
                table: "AbpAuthoritys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AbpMouleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpMouleGroups", x => x.Id);
                });
        }
    }
}
