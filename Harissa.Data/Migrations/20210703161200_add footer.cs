using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class addfooter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FooterImgs",
                columns: table => new
                {
                    FooterImgID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FooterImgItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageSettingsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterImgs", x => x.FooterImgID);
                    table.ForeignKey(
                        name: "FK_FooterImgs_PageSettings_PageSettingsID",
                        column: x => x.PageSettingsID,
                        principalTable: "PageSettings",
                        principalColumn: "PageSettingsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FooterImgs_PageSettingsID",
                table: "FooterImgs",
                column: "PageSettingsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FooterImgs");
        }
    }
}
