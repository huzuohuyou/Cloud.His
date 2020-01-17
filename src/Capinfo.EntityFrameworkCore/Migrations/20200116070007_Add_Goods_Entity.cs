using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capinfo.Migrations
{
    public partial class Add_Goods_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATE = table.Column<DateTime>(nullable: false),
                    PHONE = table.Column<string>(nullable: true),
                    DEPT = table.Column<string>(nullable: true),
                    USER = table.Column<string>(nullable: true),
                    PTNO = table.Column<string>(nullable: true),
                    KIND = table.Column<int>(nullable: false),
                    ROLE = table.Column<string>(nullable: true),
                    TYPE = table.Column<int>(nullable: false),
                    QUESTION = table.Column<string>(nullable: true),
                    REASON = table.Column<string>(nullable: true),
                    ANSWER = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Question", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");
        }
    }
}
