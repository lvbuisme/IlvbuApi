using Microsoft.EntityFrameworkCore.Migrations;

namespace Ilvbu.DataBase.Migrations
{
    public partial class V13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "WxOfficialPlatformLoginRecord",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostData",
                table: "WxOfficialPlatformLoginRecord",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "WxOfficialPlatformLoginRecord");

            migrationBuilder.DropColumn(
                name: "PostData",
                table: "WxOfficialPlatformLoginRecord");
        }
    }
}
