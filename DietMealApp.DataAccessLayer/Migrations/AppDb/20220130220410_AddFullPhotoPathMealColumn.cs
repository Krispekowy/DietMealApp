using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietMealApp.DataAccessLayer.Migrations.AppDb
{
    public partial class AddFullPhotoPathMealColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoFullPath",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoFullPath",
                table: "Meals");
        }
    }
}
