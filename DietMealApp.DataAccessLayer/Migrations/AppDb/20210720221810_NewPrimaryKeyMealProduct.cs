using Microsoft.EntityFrameworkCore.Migrations;

namespace DietMealApp.DataAccessLayer.Migrations
{
    public partial class NewPrimaryKeyMealProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealProducts",
                table: "MealProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealProducts",
                table: "MealProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MealProducts_MealId",
                table: "MealProducts",
                column: "MealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealProducts",
                table: "MealProducts");

            migrationBuilder.DropIndex(
                name: "IX_MealProducts_MealId",
                table: "MealProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealProducts",
                table: "MealProducts",
                columns: new[] { "MealId", "ProductId" });
        }
    }
}
