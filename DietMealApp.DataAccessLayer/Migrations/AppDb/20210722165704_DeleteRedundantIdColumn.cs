using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DietMealApp.DataAccessLayer.Migrations
{
    public partial class DeleteRedundantIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBeEdited",
                table: "DayDietMeals");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "DayDietMeals");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "DayDietMeals");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DayDietMeals");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DayDietMeals");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "DayDietMeals");

            migrationBuilder.DropColumn(
                name: "DietId",
                table: "DietDays");

            migrationBuilder.AlterColumn<float>(
                name: "Kcal",
                table: "DietDays",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "DietId",
                table: "DietDays",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DietDays_DietId",
                table: "DietDays",
                column: "DietId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietDays_Diets_DietId",
                table: "DietDays",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietDays_Diets_DietId",
                table: "DietDays");

            migrationBuilder.DropIndex(
                name: "IX_DietDays_DietId",
                table: "DietDays");

            migrationBuilder.AlterColumn<int>(
                name: "Kcal",
                table: "DietDays",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "DietDays",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DietId1",
                table: "DietDays",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanBeEdited",
                table: "DayDietMeals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "DayDietMeals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "DayDietMeals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "DayDietMeals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DayDietMeals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "DayDietMeals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DietDays_DietId1",
                table: "DietDays",
                column: "DietId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DietDays_Diets_DietId1",
                table: "DietDays",
                column: "DietId1",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
