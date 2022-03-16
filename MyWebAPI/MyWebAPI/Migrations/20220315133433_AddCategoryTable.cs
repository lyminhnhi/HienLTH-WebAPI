using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebAPI.Migrations
{
    public partial class AddCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryCode",
                table: "ProductTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTable_CategoryCode",
                table: "ProductTable",
                column: "CategoryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTable_Category_CategoryCode",
                table: "ProductTable",
                column: "CategoryCode",
                principalTable: "Category",
                principalColumn: "CategoryCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTable_Category_CategoryCode",
                table: "ProductTable");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_ProductTable_CategoryCode",
                table: "ProductTable");

            migrationBuilder.DropColumn(
                name: "CategoryCode",
                table: "ProductTable");
        }
    }
}
