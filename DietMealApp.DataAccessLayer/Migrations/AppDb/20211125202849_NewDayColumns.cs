using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietMealApp.DataAccessLayer.Migrations.AppDb
{
    public partial class NewDayColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Kcal",
                table: "Days",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<decimal>(
                name: "Carbohydrates",
                table: "Days",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Fats",
                table: "Days",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Protein",
                table: "Days",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carbohydrates",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "Fats",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Days");

            migrationBuilder.AlterColumn<float>(
                name: "Kcal",
                table: "Days",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
