using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsSite.Migrations
{
    public partial class mm20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ArticleId",
                table: "AspNetUsers",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Articles_ArticleId",
                table: "AspNetUsers",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Articles_ArticleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ArticleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "AspNetUsers");
        }
    }
}
