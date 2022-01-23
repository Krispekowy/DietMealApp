using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietMealApp.DataAccessLayer.Migrations.AppDb
{
    public partial class DayTableConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DayMeals",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "DayMeals");
        }
    }
}
