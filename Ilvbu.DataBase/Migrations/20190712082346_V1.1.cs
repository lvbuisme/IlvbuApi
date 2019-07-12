using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ilvbu.DataBase.Migrations
{
    public partial class V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FoodName = table.Column<string>(maxLength: 64, nullable: true),
                    ImagePath = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RubbishType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RubbishTypeName = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RubbishType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OpenId = table.Column<string>(maxLength: 64, nullable: true),
                    Password = table.Column<string>(maxLength: 128, nullable: true),
                    UserName = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WxOfficialPlatformLoginRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Signature = table.Column<string>(maxLength: 128, nullable: true),
                    Timestamp = table.Column<string>(maxLength: 128, nullable: true),
                    Nonce = table.Column<string>(maxLength: 128, nullable: true),
                    Echostr = table.Column<string>(maxLength: 128, nullable: true),
                    PostData = table.Column<string>(maxLength: 1000, nullable: true),
                    Message = table.Column<string>(maxLength: 1000, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WxOfficialPlatformLoginRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rubbish",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RubbishName = table.Column<string>(maxLength: 64, nullable: true),
                    RubbishTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubbish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rubbish_RubbishType_RubbishTypeId",
                        column: x => x.RubbishTypeId,
                        principalTable: "RubbishType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    FoodName = table.Column<string>(maxLength: 64, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodRecord_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WxLoginRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    SessionKey = table.Column<string>(maxLength: 64, nullable: true),
                    ExpiresIn = table.Column<string>(maxLength: 64, nullable: true),
                    Guid = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WxLoginRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WxLoginRecord_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecord_UserId",
                table: "FoodRecord",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rubbish_RubbishTypeId",
                table: "Rubbish",
                column: "RubbishTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WxLoginRecord_UserId",
                table: "WxLoginRecord",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodInfo");

            migrationBuilder.DropTable(
                name: "FoodRecord");

            migrationBuilder.DropTable(
                name: "Rubbish");

            migrationBuilder.DropTable(
                name: "WxLoginRecord");

            migrationBuilder.DropTable(
                name: "WxOfficialPlatformLoginRecord");

            migrationBuilder.DropTable(
                name: "RubbishType");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
