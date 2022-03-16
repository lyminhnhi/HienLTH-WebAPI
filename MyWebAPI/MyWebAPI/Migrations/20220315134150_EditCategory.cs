using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebAPI.Migrations
{
    public partial class EditCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTable_Category_CategoryCode",
                table: "ProductTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "CategoryTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTable",
                table: "CategoryTable",
                column: "CategoryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTable_CategoryTable_CategoryCode",
                table: "ProductTable",
                column: "CategoryCode",
                principalTable: "CategoryTable",
                principalColumn: "CategoryCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTable_CategoryTable_CategoryCode",
                table: "ProductTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTable",
                table: "CategoryTable");

            migrationBuilder.RenameTable(
                name: "CategoryTable",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTable_Category_CategoryCode",
                table: "ProductTable",
                column: "CategoryCode",
                principalTable: "Category",
                principalColumn: "CategoryCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
