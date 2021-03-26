using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class addicollectionmusictomuscilinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                        onDelete: ReferentialAction.Cascade);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicMusicPlatform");

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
    }
}
