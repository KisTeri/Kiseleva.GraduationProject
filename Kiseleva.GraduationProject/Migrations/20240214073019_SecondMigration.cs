using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiseleva.GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Organisations_OrganisationId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_OrganisationId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_OrganisationId",
                table: "Persons",
                column: "OrganisationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Organisations_OrganisationId",
                table: "Persons",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
