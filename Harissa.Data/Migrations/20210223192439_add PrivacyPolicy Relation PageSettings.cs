using Microsoft.EntityFrameworkCore.Migrations;

namespace Harissa.Data.Migrations
{
    public partial class addPrivacyPolicyRelationPageSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PageSettingsID",
                table: "PrivacyPolicies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PrivacyPolicies_PageSettingsID",
                table: "PrivacyPolicies",
                column: "PageSettingsID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivacyPolicies_PageSettings_PageSettingsID",
                table: "PrivacyPolicies",
                column: "PageSettingsID",
                principalTable: "PageSettings",
                principalColumn: "PageSettingsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivacyPolicies_PageSettings_PageSettingsID",
                table: "PrivacyPolicies");

            migrationBuilder.DropIndex(
                name: "IX_PrivacyPolicies_PageSettingsID",
                table: "PrivacyPolicies");

            migrationBuilder.DropColumn(
                name: "PageSettingsID",
                table: "PrivacyPolicies");
        }
    }
}
