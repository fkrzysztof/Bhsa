using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class addPageSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PageSettingsID",
                table: "SocialMedias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PageSettings",
                columns: table => new
                {
                    PageSettingsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoPicture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageSettings", x => x.PageSettingsID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_PageSettingsID",
                table: "SocialMedias",
                column: "PageSettingsID");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_PageSettings_PageSettingsID",
                table: "SocialMedias",
                column: "PageSettingsID",
                principalTable: "PageSettings",
                principalColumn: "PageSettingsID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_PageSettings_PageSettingsID",
                table: "SocialMedias");

            migrationBuilder.DropTable(
                name: "PageSettings");

            migrationBuilder.DropIndex(
                name: "IX_SocialMedias_PageSettingsID",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "PageSettingsID",
                table: "SocialMedias");
        }
    }
}
