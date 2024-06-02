﻿// <auto-generated />
using System;
using Kiseleva.GraduationProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kiseleva.GraduationProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240425194309_FifteenthMigration")]
    partial class FifteenthMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apartment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Index")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KindOfAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Settlement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfBeginning")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfEnding")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfSigning")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("ProgramOfEducationId")
                        .HasColumnType("int");

                    b.Property<string>("SigningBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValidityPeriod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId")
                        .IsUnique()
                        .HasFilter("[OrganisationId] IS NOT NULL");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProgramOfEducationId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.DocumentOfPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("IssuedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IssuedWhen")
                        .HasColumnType("date");

                    b.Property<int>("KindOfDocumentId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("SNILS")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KindOfDocumentId");

                    b.HasIndex("PersonId");

                    b.ToTable("DocumentsOfPerson");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.KindOfDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Kind")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KindOfDocuments");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.KindOfEducation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KindOfEducations");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BIK")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("INN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("OGRN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasFilter("[PersonId] IS NOT NULL");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KindOfPerson")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Position")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasFilter("[AddressId] IS NOT NULL");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.ProgramOfEducation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("EducationLength")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoursAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("KindOfEducationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceInWords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KindOfEducationId");

                    b.ToTable("ProgramOfEducations");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.Address", b =>
                {
                    b.HasOne("Kiseleva.GraduationProject.Entities.Organisation", "Organisation")
                        .WithMany("Addresses")
                        .HasForeignKey("OrganisationId");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.Contract", b =>
                {
                    b.HasOne("Kiseleva.GraduationProject.Entities.Organisation", "Organisation")
                        .WithOne("Contract")
                        .HasForeignKey("Kiseleva.GraduationProject.Entities.Contract", "OrganisationId");

                    b.HasOne("Kiseleva.GraduationProject.Entities.Person", "Person")
                        .WithMany("Contracts")
                        .HasForeignKey("PersonId");

                    b.HasOne("Kiseleva.GraduationProject.Entities.ProgramOfEducation", "ProgramOfEducation")
                        .WithMany("Contracts")
                        .HasForeignKey("ProgramOfEducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organisation");

                    b.Navigation("Person");

                    b.Navigation("ProgramOfEducation");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.DocumentOfPerson", b =>
                {
                    b.HasOne("Kiseleva.GraduationProject.Entities.KindOfDocument", "KindOfDocument")
                        .WithMany("DocumentsOfPerson")
                        .HasForeignKey("KindOfDocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kiseleva.GraduationProject.Entities.Person", "Person")
                        .WithMany("DocumentsOfPerson")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KindOfDocument");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.File", b =>
                {
                    b.HasOne("Kiseleva.GraduationProject.Entities.Person", "Person")
                        .WithMany("Files")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.Organisation", b =>
                {
                    b.HasOne("Kiseleva.GraduationProject.Entities.Person", "Person")
                        .WithOne("Organisation")
                        .HasForeignKey("Kiseleva.GraduationProject.Entities.Organisation", "PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.Person", b =>
                {
                    b.HasOne("Kiseleva.GraduationProject.Entities.Address", "Address")
                        .WithOne("Person")
                        .HasForeignKey("Kiseleva.GraduationProject.Entities.Person", "AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.ProgramOfEducation", b =>
                {
                    b.HasOne("Kiseleva.GraduationProject.Entities.KindOfEducation", "KindOfEducation")
                        .WithMany("ProgramsOfEducation")
                        .HasForeignKey("KindOfEducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KindOfEducation");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.Address", b =>
                {
                    b.Navigation("Person");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.KindOfDocument", b =>
                {
                    b.Navigation("DocumentsOfPerson");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.KindOfEducation", b =>
                {
                    b.Navigation("ProgramsOfEducation");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.Organisation", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Contract")
                        .IsRequired();
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.Person", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("DocumentsOfPerson");

                    b.Navigation("Files");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("Kiseleva.GraduationProject.Entities.ProgramOfEducation", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
