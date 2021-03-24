using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class relationmusicplatformsmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_MusicPlatforms_MusicPlatformID",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_MusicPlatformID",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "MusicPlatformID",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "MusicPlatform_ID",
                table: "Musics");

            migrationBuilder.CreateTable(
                name: "MusicMusicPlatform",
                columns: table => new
                {
                    MusicID = table.Column<int>(type: "int", nullable: false),
                    MusicPlatformsMusicPlatformID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicMusicPlatform", x => new { x.MusicID, x.MusicPlatformsMusicPlatformID });
                    table.ForeignKey(
                        name: "FK_MusicMusicPlatform_MusicPlatforms_MusicPlatformsMusicPlatformID",
                        column: x => x.MusicPlatformsMusicPlatformID,
                        principalTable: "MusicPlatforms",
                        principalColumn: "MusicPlatformID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicMusicPlatform_Musics_MusicID",
                        column: x => x.MusicID,
                        principalTable: "Musics",
                        principalColumn: "MusicID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicMusicPlatform_MusicPlatformsMusicPlatformID",
                table: "MusicMusicPlatform",
                column: "MusicPlatformsMusicPlatformID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicMusicPlatform");

            migrationBuilder.AddColumn<int>(
                name: "MusicPlatformID",
                table: "Musics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MusicPlatform_ID",
                table: "Musics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Musics_MusicPlatformID",
                table: "Musics",
                column: "MusicPlatformID");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_MusicPlatforms_MusicPlatformID",
                table: "Musics",
                column: "MusicPlatformID",
                principalTable: "MusicPlatforms",
                principalColumn: "MusicPlatformID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
