using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class relationmusicplatforms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_MusicPlatform_MusicPlatformID",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicPlatform",
                table: "MusicPlatform");

            migrationBuilder.RenameTable(
                name: "MusicPlatform",
                newName: "MusicPlatforms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicPlatforms",
                table: "MusicPlatforms",
                column: "MusicPlatformID");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_MusicPlatforms_MusicPlatformID",
                table: "Musics",
                column: "MusicPlatformID",
                principalTable: "MusicPlatforms",
                principalColumn: "MusicPlatformID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_MusicPlatforms_MusicPlatformID",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicPlatforms",
                table: "MusicPlatforms");

            migrationBuilder.RenameTable(
                name: "MusicPlatforms",
                newName: "MusicPlatform");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicPlatform",
                table: "MusicPlatform",
                column: "MusicPlatformID");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_MusicPlatform_MusicPlatformID",
                table: "Musics",
                column: "MusicPlatformID",
                principalTable: "MusicPlatform",
                principalColumn: "MusicPlatformID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
