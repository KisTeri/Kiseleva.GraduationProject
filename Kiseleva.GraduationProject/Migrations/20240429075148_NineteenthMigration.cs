using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiseleva.GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class NineteenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfEnding",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "SigningBody",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "ValidityPeriod",
                table: "Contract");

            migrationBuilder.AddColumn<bool>(
                name: "CZN",
                table: "Organisations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CZN",
                table: "Organisations");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEnding",
                table: "Contract",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SigningBody",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValidityPeriod",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
