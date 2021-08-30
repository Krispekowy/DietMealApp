using Microsoft.EntityFrameworkCore.Migrations;

namespace DietMealApp.DataAccessLayer.Migrations.AppDb
{
    public partial class ModifyDayTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietDays_Diets_IdDiety",
                table: "DietDays");

            migrationBuilder.DropColumn(
                name: "Breakfast",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "Brunch",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "Dinner",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "Lunch",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "Tea",
                table: "Days");

            migrationBuilder.RenameColumn(
                name: "IdDiety",
                table: "DietDays",
                newName: "DietId");

            migrationBuilder.RenameIndex(
                name: "IX_DietDays_IdDiety",
                table: "DietDays",
                newName: "IX_DietDays_DietId");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "DayMeals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DietDays_Diets_DietId",
                table: "DietDays",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietDays_Diets_DietId",
                table: "DietDays");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "DayMeals");

            migrationBuilder.RenameColumn(
                name: "DietId",
                table: "DietDays",
                newName: "IdDiety");

            migrationBuilder.RenameIndex(
                name: "IX_DietDays_DietId",
                table: "DietDays",
                newName: "IX_DietDays_IdDiety");

            migrationBuilder.AddColumn<int>(
                name: "Breakfast",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Brunch",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dinner",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Lunch",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tea",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DietDays_Diets_IdDiety",
                table: "DietDays",
                column: "IdDiety",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
