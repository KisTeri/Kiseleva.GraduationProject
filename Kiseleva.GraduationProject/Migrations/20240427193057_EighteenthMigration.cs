using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiseleva.GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class EighteenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentOfOrganisation",
                table: "Organisations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentOfOrganisation",
                table: "Organisations");
        }
    }
}
