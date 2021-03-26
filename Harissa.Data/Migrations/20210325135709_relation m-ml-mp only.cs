using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class relationmmlmponly : Migration
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
                    MusicPlatformsMusicPlatformID = table.Column<int>(type: "int", nullable: false),
                    MusicsMusicID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicMusicPlatform", x => new { x.MusicPlatformsMusicPlatformID, x.MusicsMusicID });
                    table.ForeignKey(
                        name: "FK_MusicMusicPlatform_MusicPlatforms_MusicPlatformsMusicPlatformID",
                        column: x => x.MusicPlatformsMusicPlatformID,
                        principalTable: "MusicPlatforms",
                        principalColumn: "MusicPlatformID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MusicMusicPlatform_Musics_MusicsMusicID",
                        column: x => x.MusicsMusicID,
                        principalTable: "Musics",
                        principalColumn: "MusicID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicMusicPlatform_MusicsMusicID",
                table: "MusicMusicPlatform",
                column: "MusicsMusicID");
        }
    }
}
