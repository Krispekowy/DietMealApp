using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietMealApp.DataAccessLayer.Migrations.AppDb
{
    public partial class NewPKsForShoppingListTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingListProducts",
                table: "ShoppingListProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingListMeals",
                table: "ShoppingListMeals");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ShoppingListProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ShoppingListMeals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingListProducts",
                table: "ShoppingListProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingListMeals",
                table: "ShoppingListMeals",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListProducts_ProductId",
                table: "ShoppingListProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListMeals_MealId",
                table: "ShoppingListMeals",
                column: "MealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingListProducts",
                table: "ShoppingListProducts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListProducts_ProductId",
                table: "ShoppingListProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingListMeals",
                table: "ShoppingListMeals");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListMeals_MealId",
                table: "ShoppingListMeals");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingListProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingListMeals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingListProducts",
                table: "ShoppingListProducts",
                columns: new[] { "ProductId", "ShoppingListId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingListMeals",
                table: "ShoppingListMeals",
                columns: new[] { "MealId", "ShoppingListId" });
        }
    }
}
