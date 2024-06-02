using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiseleva.GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class SeventeenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Persons_PersonId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Contract_OrganisationId",
                table: "Contract");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Files",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrganisationId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_OrganisationId",
                table: "Files",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_OrganisationId",
                table: "Contract",
                column: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Organisations_OrganisationId",
                table: "Files",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Persons_PersonId",
                table: "Files",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Organisations_OrganisationId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Persons_PersonId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_OrganisationId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Contract_OrganisationId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "OrganisationId",
                table: "Files");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_OrganisationId",
                table: "Contract",
                column: "OrganisationId",
                unique: true,
                filter: "[OrganisationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Persons_PersonId",
                table: "Files",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
