using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiseleva.GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KindOfDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kind = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindOfDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KindOfEducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindOfEducations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    INN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OGRN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramOfEducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceInWords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoursAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationLength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    KindOfEducationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramOfEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramOfEducations_KindOfEducations_KindOfEducationId",
                        column: x => x.KindOfEducationId,
                        principalTable: "KindOfEducations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settlement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Building = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KindOfAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    OrganisationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KindOfPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    OrganisationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfSigning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidityPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBeginning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfEnding = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SigningBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    ProgramOfEducationId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contract_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contract_ProgramOfEducations_ProgramOfEducationId",
                        column: x => x.ProgramOfEducationId,
                        principalTable: "ProgramOfEducations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsOfPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuedWhen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SNILS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    KindOfDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsOfPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentsOfPerson_KindOfDocuments_KindOfDocumentId",
                        column: x => x.KindOfDocumentId,
                        principalTable: "KindOfDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentsOfPerson_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_OrganisationId",
                table: "Addresses",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_OrganisationId",
                table: "Contract",
                column: "OrganisationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_PersonId",
                table: "Contract",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ProgramOfEducationId",
                table: "Contract",
                column: "ProgramOfEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsOfPerson_KindOfDocumentId",
                table: "DocumentsOfPerson",
                column: "KindOfDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsOfPerson_PersonId",
                table: "DocumentsOfPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressId",
                table: "Persons",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_OrganisationId",
                table: "Persons",
                column: "OrganisationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramOfEducations_KindOfEducationId",
                table: "ProgramOfEducations",
                column: "KindOfEducationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "DocumentsOfPerson");

            migrationBuilder.DropTable(
                name: "ProgramOfEducations");

            migrationBuilder.DropTable(
                name: "KindOfDocuments");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "KindOfEducations");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Organisations");
        }
    }
}
