using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiseleva.GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class FifteenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Organisations_OrganisationId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_OrganisationId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "OrganisationId",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Organisations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_PersonId",
                table: "Organisations",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Organisations_Persons_PersonId",
                table: "Organisations",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organisations_Persons_PersonId",
                table: "Organisations");

            migrationBuilder.DropIndex(
                name: "IX_Organisations_PersonId",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Organisations");

            migrationBuilder.AddColumn<int>(
                name: "OrganisationId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_OrganisationId",
                table: "Persons",
                column: "OrganisationId",
                unique: true,
                filter: "[OrganisationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Organisations_OrganisationId",
                table: "Persons",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "Id");
        }
    }
}
