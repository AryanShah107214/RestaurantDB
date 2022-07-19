using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantDB.Migrations
{
    public partial class MigrationTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodMenu_FoodItem_FoodItemID",
                table: "FoodMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Order_OrderID",
                table: "Invoice");

            migrationBuilder.DropTable(
                name: "FoodItem");

            migrationBuilder.DropIndex(
                name: "IX_FoodMenu_FoodItemID",
                table: "FoodMenu");

            migrationBuilder.DropColumn(
                name: "FoodItemID",
                table: "FoodMenu");

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "Invoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FoodName",
                table: "FoodMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Order_OrderID",
                table: "Invoice",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Order_OrderID",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "FoodName",
                table: "FoodMenu");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenu_FoodItemID",
                table: "FoodMenu",
                column: "FoodItemID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItem_OrderID",
                table: "FoodItem",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMenu_FoodItem_FoodItemID",
                table: "FoodMenu",
                column: "FoodItemID",
                principalTable: "FoodItem",
                principalColumn: "FoodItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Order_OrderID",
                table: "Invoice",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
