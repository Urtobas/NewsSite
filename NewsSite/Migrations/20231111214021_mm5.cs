using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsSite.Migrations
{
    public partial class mm5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndexCountPopularArticles = table.Column<int>(type: "int", nullable: false),
                    IndexCountLastDayArticles = table.Column<int>(type: "int", nullable: false),
                    IndexCountReadMoreArticles = table.Column<int>(type: "int", nullable: false),
                    IndexCountImportantArticles = table.Column<int>(type: "int", nullable: false),
                    IndexCountSocialArticles = table.Column<int>(type: "int", nullable: false),
                    IndexCountSportArticles = table.Column<int>(type: "int", nullable: false),
                    IndexCountFinanceArticles = table.Column<int>(type: "int", nullable: false),
                    IndexCountCriminalArticles = table.Column<int>(type: "int", nullable: false),
                    IndexCountUkraineWarArticles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings");
        }
    }
}
