using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class addicollectionmlinktomusci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MusicID",
                table: "MusicPlatforms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlatforms_MusicID",
                table: "MusicPlatforms",
                column: "MusicID");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicPlatforms_Musics_MusicID",
                table: "MusicPlatforms",
                column: "MusicID",
                principalTable: "Musics",
                principalColumn: "MusicID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicPlatforms_Musics_MusicID",
                table: "MusicPlatforms");

            migrationBuilder.DropIndex(
                name: "IX_MusicPlatforms_MusicID",
                table: "MusicPlatforms");

            migrationBuilder.DropColumn(
                name: "MusicID",
                table: "MusicPlatforms");
        }
    }
}
