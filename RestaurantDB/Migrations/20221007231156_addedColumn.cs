using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantDB.Migrations
{
    public partial class addedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "FoodMenu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "FoodMenu");
        }
    }
}
