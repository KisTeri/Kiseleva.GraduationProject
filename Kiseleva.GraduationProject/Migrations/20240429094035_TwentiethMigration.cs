using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiseleva.GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class TwentiethMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CZN",
                table: "Organisations");

            migrationBuilder.AddColumn<int>(
                name: "CZNId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CZNId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CZNs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankForRS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KPP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OGRN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentOfOrganisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CZNs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CZNs_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_CZNId",
                table: "Files",
                column: "CZNId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CZNId",
                table: "Addresses",
                column: "CZNId");

            migrationBuilder.CreateIndex(
                name: "IX_CZNs_PersonId",
                table: "CZNs",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_CZNs_CZNId",
                table: "Addresses",
                column: "CZNId",
                principalTable: "CZNs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_CZNs_CZNId",
                table: "Files",
                column: "CZNId",
                principalTable: "CZNs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CZNs_CZNId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_CZNs_CZNId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "CZNs");

            migrationBuilder.DropIndex(
                name: "IX_Files_CZNId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CZNId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CZNId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CZNId",
                table: "Addresses");

            migrationBuilder.AddColumn<bool>(
                name: "CZN",
                table: "Organisations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
