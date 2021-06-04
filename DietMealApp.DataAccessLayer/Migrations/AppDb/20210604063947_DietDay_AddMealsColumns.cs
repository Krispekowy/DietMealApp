using Microsoft.EntityFrameworkCore.Migrations;

namespace DietMealApp.DataAccessLayer.Migrations
{
    public partial class DietDay_AddMealsColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayName",
                table: "DietDays",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Breakfast",
                table: "DietDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Brunch",
                table: "DietDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dinner",
                table: "DietDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Lunch",
                table: "DietDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tea",
                table: "DietDays",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Breakfast",
                table: "DietDays");

            migrationBuilder.DropColumn(
                name: "Brunch",
                table: "DietDays");

            migrationBuilder.DropColumn(
                name: "Dinner",
                table: "DietDays");

            migrationBuilder.DropColumn(
                name: "Lunch",
                table: "DietDays");

            migrationBuilder.DropColumn(
                name: "Tea",
                table: "DietDays");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DietDays",
                newName: "DayName");
        }
    }
}
