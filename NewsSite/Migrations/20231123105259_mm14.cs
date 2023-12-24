using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsSite.Migrations
{
    public partial class mm14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MenuBorderColor",
                table: "SettingsColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MenuBorderHoverColor",
                table: "SettingsColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuBorderColor",
                table: "SettingsColors");

            migrationBuilder.DropColumn(
                name: "MenuBorderHoverColor",
                table: "SettingsColors");
        }
    }
}
