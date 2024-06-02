using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiseleva.GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class SixteenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentDetails",
                table: "Organisations",
                newName: "RS");

            migrationBuilder.AddColumn<string>(
                name: "BankForRS",
                table: "Organisations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KPP",
                table: "Organisations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KS",
                table: "Organisations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankForRS",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "KPP",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "KS",
                table: "Organisations");

            migrationBuilder.RenameColumn(
                name: "RS",
                table: "Organisations",
                newName: "PaymentDetails");
        }
    }
}
