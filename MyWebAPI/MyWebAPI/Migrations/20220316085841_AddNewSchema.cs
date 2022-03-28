using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebAPI.Migrations
{
    public partial class AddNewSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderTable",
                columns: table => new
                {
                    OrderCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusOrder = table.Column<int>(type: "int", nullable: false),
                    RecipientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTable", x => x.OrderCode);
                });

            migrationBuilder.CreateTable(
                name: "ProductOdersTable",
                columns: table => new
                {
                    ProductCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    PriceForSale = table.Column<double>(type: "float", nullable: false),
                    PromotionForSale = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOdersTable", x => new { x.OrderCode, x.ProductCode });
                    table.ForeignKey(
                        name: "FK_ProductOder_Order",
                        column: x => x.OrderCode,
                        principalTable: "OrderTable",
                        principalColumn: "OrderCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOder_Product",
                        column: x => x.ProductCode,
                        principalTable: "ProductTable",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOdersTable_ProductCode",
                table: "ProductOdersTable",
                column: "ProductCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOdersTable");

            migrationBuilder.DropTable(
                name: "OrderTable");
        }
    }
}
