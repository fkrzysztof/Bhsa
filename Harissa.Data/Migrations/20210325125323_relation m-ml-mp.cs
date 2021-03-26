using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class relationmmlmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicMusicPlatform");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusicMusicPlatform",
                columns: table => new
                {
                    MusicLinksMusicID = table.Column<int>(type: "int", nullable: false),
                    MusicPlatformsMusicPlatformID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicMusicPlatform", x => new { x.MusicLinksMusicID, x.MusicPlatformsMusicPlatformID });
                    table.ForeignKey(
                        name: "FK_MusicMusicPlatform_MusicPlatforms_MusicPlatformsMusicPlatformID",
                        column: x => x.MusicPlatformsMusicPlatformID,
                        principalTable: "MusicPlatforms",
                        principalColumn: "MusicPlatformID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MusicMusicPlatform_Musics_MusicLinksMusicID",
                        column: x => x.MusicLinksMusicID,
                        principalTable: "Musics",
                        principalColumn: "MusicID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicMusicPlatform_MusicPlatformsMusicPlatformID",
                table: "MusicMusicPlatform",
                column: "MusicPlatformsMusicPlatformID");
        }
    }
}
