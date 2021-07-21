using Microsoft.EntityFrameworkCore.Migrations;

namespace DietMealApp.DataAccessLayer.Migrations
{
    public partial class CreateTypeIdForMealProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MealProducts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "MealProducts");
        }
    }
}
