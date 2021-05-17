using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class IframeIndexPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IframeText",
                table: "PageSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IframeTitle",
                table: "PageSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IframeVideo",
                table: "PageSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IframeText",
                table: "PageSettings");

            migrationBuilder.DropColumn(
                name: "IframeTitle",
                table: "PageSettings");

            migrationBuilder.DropColumn(
                name: "IframeVideo",
                table: "PageSettings");
        }
    }
}
