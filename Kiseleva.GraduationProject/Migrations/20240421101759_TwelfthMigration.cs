using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiseleva.GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class TwelfthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "ProgramOfEducations",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Persons",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Organisations",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "KindOfEducations",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "KindOfDocuments",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "DocumentsOfPerson",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Contract",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Addresses",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "ProgramOfEducations",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Persons",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Organisations",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "KindOfEducations",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "KindOfDocuments",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Files",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Files",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "DocumentsOfPerson",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Contract",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Addresses",
                type: "datetimeoffset",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ProgramOfEducations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "KindOfEducations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "KindOfDocuments");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DocumentsOfPerson");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProgramOfEducations",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Persons",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Organisations",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "KindOfEducations",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "KindOfDocuments",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "DocumentsOfPerson",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Contract",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Addresses",
                newName: "IsDelete");
        }
    }
}
