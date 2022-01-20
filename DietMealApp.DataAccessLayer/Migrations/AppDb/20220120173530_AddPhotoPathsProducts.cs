using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietMealApp.DataAccessLayer.Migrations.AppDb
{
    public partial class AddPhotoPathsProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Products",
                newName: "PhotoFullPath");

            migrationBuilder.AddColumn<string>(
                name: "Photo150x150Path",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "MealProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo150x150Path",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PhotoFullPath",
                table: "Products",
                newName: "PhotoPath");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "MealProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
