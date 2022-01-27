using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietMealApp.DataAccessLayer.Migrations.AppDb
{
    public partial class NumberOfServingsColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfServings",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfServings",
                table: "Meals");
        }
    }
}
