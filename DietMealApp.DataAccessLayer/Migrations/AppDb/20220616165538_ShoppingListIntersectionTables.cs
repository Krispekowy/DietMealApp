using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietMealApp.DataAccessLayer.Migrations.AppDb
{
    public partial class ShoppingListIntersectionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingListProducts",
                table: "ShoppingListProducts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListProducts_ProductId",
                table: "ShoppingListProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingListProducts",
                table: "ShoppingListProducts",
                columns: new[] { "ProductId", "ShoppingListId" });

            migrationBuilder.CreateTable(
                name: "ShoppingListDays",
                columns: table => new
                {
                    ShoppingListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListDays", x => new { x.DayId, x.ShoppingListId });
                    table.ForeignKey(
                        name: "FK_ShoppingListDays_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListDays_ShoppingList_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListMeals",
                columns: table => new
                {
                    ShoppingListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListMeals", x => new { x.MealId, x.ShoppingListId });
                    table.ForeignKey(
                        name: "FK_ShoppingListMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListMeals_ShoppingList_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListDays_ShoppingListId",
                table: "ShoppingListDays",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListMeals_ShoppingListId",
                table: "ShoppingListMeals",
                column: "ShoppingListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingListDays");

            migrationBuilder.DropTable(
                name: "ShoppingListMeals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingListProducts",
                table: "ShoppingListProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingListProducts",
                table: "ShoppingListProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListProducts_ProductId",
                table: "ShoppingListProducts",
                column: "ProductId");
        }
    }
}
