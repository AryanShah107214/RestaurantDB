using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantDB.Migrations
{
    public partial class updatedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodMenu_FoodItem_FoodItemID",
                table: "FoodMenu");

            migrationBuilder.DropTable(
                name: "FoodItem");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_FoodMenu_FoodItemID",
                table: "FoodMenu");

            migrationBuilder.DropColumn(
                name: "FoodItemID",
                table: "FoodMenu");

            migrationBuilder.AlterColumn<double>(
                name: "Cost",
                table: "Order",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "FoodName",
                table: "FoodMenu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodName",
                table: "FoodMenu");

            migrationBuilder.AlterColumn<int>(
                name: "Cost",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "FoodItemID",
                table: "FoodMenu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FoodItem",
                columns: table => new
                {
                    FoodItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItem", x => x.FoodItemID);
                    table.ForeignKey(
                        name: "FK_FoodItem_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoice_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenu_FoodItemID",
                table: "FoodMenu",
                column: "FoodItemID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItem_OrderID",
                table: "FoodItem",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_OrderID",
                table: "Invoice",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMenu_FoodItem_FoodItemID",
                table: "FoodMenu",
                column: "FoodItemID",
                principalTable: "FoodItem",
                principalColumn: "FoodItemID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
