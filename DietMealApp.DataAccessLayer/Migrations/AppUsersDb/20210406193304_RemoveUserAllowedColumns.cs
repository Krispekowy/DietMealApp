using Microsoft.EntityFrameworkCore.Migrations;

namespace DietMealApp.DataAccessLayer.Migrations.AppUsersDb
{
    public partial class RemoveUserAllowedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlertSent",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AllowSublabelsModule",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompleatedOfferPreferencesForm",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsConfirmedFromIntranet",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RemovalAlertSent",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserHasCompleatedContract",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserHasElectroniclySignedContract",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserHasLabel",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AlertSent",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowSublabelsModule",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CompleatedOfferPreferencesForm",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmedFromIntranet",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RemovalAlertSent",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UserHasCompleatedContract",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UserHasElectroniclySignedContract",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UserHasLabel",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
