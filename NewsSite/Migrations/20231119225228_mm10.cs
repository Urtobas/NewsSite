using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsSite.Migrations
{
    public partial class mm10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlockquoteBorderColor",
                table: "SettingsColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlockquoteTextColor",
                table: "SettingsColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeaderHoverColor",
                table: "SettingsColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockquoteBorderColor",
                table: "SettingsColors");

            migrationBuilder.DropColumn(
                name: "BlockquoteTextColor",
                table: "SettingsColors");

            migrationBuilder.DropColumn(
                name: "HeaderHoverColor",
                table: "SettingsColors");
        }
    }
}
