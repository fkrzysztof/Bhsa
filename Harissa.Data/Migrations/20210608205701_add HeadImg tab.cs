using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class addHeadImgtab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.CreateTable(
                name: "HeadImgs",
                columns: table => new
                {
                    HeadImgID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadMediaItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageSettingsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadImgs", x => x.HeadImgID);
                    table.ForeignKey(
                        name: "FK_HeadImgs_PageSettings_PageSettingsID",
                        column: x => x.PageSettingsID,
                        principalTable: "PageSettings",
                        principalColumn: "PageSettingsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeadImgs_PageSettingsID",
                table: "HeadImgs",
                column: "PageSettingsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeadImgs");

 
        }
    }
}
