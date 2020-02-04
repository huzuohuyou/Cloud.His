using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capinfo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PTNO = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    GENDER = table.Column<string>(nullable: true),
                    BIRTHDATE = table.Column<string>(nullable: true),
                    IDNO = table.Column<string>(nullable: true),
                    STARTDATE = table.Column<string>(nullable: true),
                    LASTDATE = table.Column<string>(nullable: true),
                    POST_CODE = table.Column<string>(nullable: true),
                    HOME_ADDRESS = table.Column<string>(nullable: true),
                    TEL = table.Column<string>(nullable: true),
                    TEL1 = table.Column<string>(nullable: true),
                    CPNO = table.Column<string>(nullable: true),
                    CARD_TYPE = table.Column<string>(nullable: true),
                    CONSULT = table.Column<string>(nullable: true),
                    MARRIAGE = table.Column<string>(nullable: true),
                    NATION = table.Column<string>(nullable: true),
                    NATIONALITY = table.Column<string>(nullable: true),
                    WORK = table.Column<string>(nullable: true),
                    COMPANY_POST = table.Column<string>(nullable: true),
                    COMPANY_ADDRESS = table.Column<string>(nullable: true),
                    COMPANY_TEL = table.Column<string>(nullable: true),
                    COMPANY_NAME = table.Column<string>(nullable: true),
                    BIRTHPLACE = table.Column<string>(nullable: true),
                    GKIHO2 = table.Column<string>(nullable: true),
                    BANNO = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
