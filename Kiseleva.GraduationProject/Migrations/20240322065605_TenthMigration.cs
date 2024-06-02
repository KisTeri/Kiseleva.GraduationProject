using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiseleva.GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class TenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Files_PersonId",
                table: "Files",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Persons_PersonId",
                table: "Files",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Persons_PersonId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_PersonId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Files");
        }
    }
}
