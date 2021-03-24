using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class addclassmusiclinkclassnewrelatonmusicmusiclinkmusicplatform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicMusicPlatform");

            migrationBuilder.DropColumn(
                name: "LinkToMusic",
                table: "Musics");

            migrationBuilder.CreateTable(
                name: "MusicLinks",
                columns: table => new
                {
                    MusicLinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkToAlbum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusicPlatformID = table.Column<int>(type: "int", nullable: false),
                    MusicID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLinks", x => x.MusicLinkID);
                    table.ForeignKey(
                        name: "FK_MusicLinks_MusicPlatforms_MusicPlatformID",
                        column: x => x.MusicPlatformID,
                        principalTable: "MusicPlatforms",
                        principalColumn: "MusicPlatformID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MusicLinks_Musics_MusicID",
                        column: x => x.MusicID,
                        principalTable: "Musics",
                        principalColumn: "MusicID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicLinks_MusicID",
                table: "MusicLinks",
                column: "MusicID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLinks_MusicPlatformID",
                table: "MusicLinks",
                column: "MusicPlatformID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicLinks");

            migrationBuilder.AddColumn<string>(
                name: "LinkToMusic",
                table: "Musics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                        onDelete: ReferentialAction.NoAction);
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
    }
}
