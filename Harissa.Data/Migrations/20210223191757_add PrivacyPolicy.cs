using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class addPrivacyPolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_mediaPatronages",
                table: "mediaPatronages");

            migrationBuilder.RenameTable(
                name: "mediaPatronages",
                newName: "MediaPatronages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaPatronages",
                table: "MediaPatronages",
                column: "MediaPatronageID");

            migrationBuilder.CreateTable(
                name: "PrivacyPolicies",
                columns: table => new
                {
                    PrivacyPolicyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivacyPolicies", x => x.PrivacyPolicyID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrivacyPolicies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaPatronages",
                table: "MediaPatronages");

            migrationBuilder.RenameTable(
                name: "MediaPatronages",
                newName: "mediaPatronages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mediaPatronages",
                table: "mediaPatronages",
                column: "MediaPatronageID");
        }
    }
}
