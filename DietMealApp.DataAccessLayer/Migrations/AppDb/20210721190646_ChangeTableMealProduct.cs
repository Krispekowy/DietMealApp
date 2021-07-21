using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DietMealApp.DataAccessLayer.Migrations
{
    public partial class ChangeTableMealProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBeEdited",
                table: "MealProducts");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "MealProducts");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "MealProducts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MealProducts");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "MealProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanBeEdited",
                table: "MealProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "MealProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "MealProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MealProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "MealProducts",
                type: "datetime2",
                nullable: true);
        }
    }
}
