using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsSite.Migrations
{
    public partial class mm17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkColor",
                table: "SettingsColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SearchPaginationCount",
                table: "AppSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkColor",
                table: "SettingsColors");

            migrationBuilder.DropColumn(
                name: "SearchPaginationCount",
                table: "AppSettings");
        }
    }
}
