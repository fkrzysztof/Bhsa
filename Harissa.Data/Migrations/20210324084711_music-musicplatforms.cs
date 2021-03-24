using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class musicmusicplatforms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IFrame",
                table: "Musics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Musics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkToMusic",
                table: "Musics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Musics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Year",
                table: "Musics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "MusicPlatform",
                columns: table => new
                {
                    MusicPlatformID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicPlatform", x => x.MusicPlatformID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musics_MusicPlatformID",
                table: "Musics",
                column: "MusicPlatformID");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_MusicPlatform_MusicPlatformID",
                table: "Musics",
                column: "MusicPlatformID",
                principalTable: "MusicPlatform",
                principalColumn: "MusicPlatformID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_MusicPlatform_MusicPlatformID",
                table: "Musics");

            migrationBuilder.DropTable(
                name: "MusicPlatform");

            migrationBuilder.DropIndex(
                name: "IX_Musics_MusicPlatformID",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "LinkToMusic",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "MusicPlatformID",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "MusicPlatform_ID",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Musics");

            migrationBuilder.AlterColumn<string>(
                name: "IFrame",
                table: "Musics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
