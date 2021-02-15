using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class relationsocialmediapagesettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_PageSettings_PageSettingsID",
                table: "SocialMedias");

            migrationBuilder.AlterColumn<int>(
                name: "PageSettingsID",
                table: "SocialMedias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_PageSettings_PageSettingsID",
                table: "SocialMedias",
                column: "PageSettingsID",
                principalTable: "PageSettings",
                principalColumn: "PageSettingsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_PageSettings_PageSettingsID",
                table: "SocialMedias");

            migrationBuilder.AlterColumn<int>(
                name: "PageSettingsID",
                table: "SocialMedias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_PageSettings_PageSettingsID",
                table: "SocialMedias",
                column: "PageSettingsID",
                principalTable: "PageSettings",
                principalColumn: "PageSettingsID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
