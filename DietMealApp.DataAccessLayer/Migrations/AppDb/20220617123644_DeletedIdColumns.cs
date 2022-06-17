using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietMealApp.DataAccessLayer.Migrations.AppDb
{
    public partial class DeletedIdColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingListProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingListMeals");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingListDays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ShoppingListDays",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
