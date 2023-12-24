using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsSite.Migrations
{
    public partial class mm19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminBackgroundColor",
                table: "SettingsColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdminFontColor",
                table: "SettingsColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdminHeaderColor",
                table: "SettingsColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdminMenuBackgroundColor",
                table: "SettingsColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdminMenuFontColor",
                table: "SettingsColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdminMenuFontHoverColor",
                table: "SettingsColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminBackgroundColor",
                table: "SettingsColors");

            migrationBuilder.DropColumn(
                name: "AdminFontColor",
                table: "SettingsColors");

            migrationBuilder.DropColumn(
                name: "AdminHeaderColor",
                table: "SettingsColors");

            migrationBuilder.DropColumn(
                name: "AdminMenuBackgroundColor",
                table: "SettingsColors");

            migrationBuilder.DropColumn(
                name: "AdminMenuFontColor",
                table: "SettingsColors");

            migrationBuilder.DropColumn(
                name: "AdminMenuFontHoverColor",
                table: "SettingsColors");
        }
    }
}
