using Kiseleva.GraduationProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiseleva.GraduationProject.Configuration
{
    public class OrganisationEntityTypeConfiguration : IEntityTypeConfiguration<Organisation>
    {
        public void Configure(EntityTypeBuilder<Organisation> builder)
        {
            builder.HasKey(c => c.Id)
                .HasName("PK_Organisation_Id");

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(c => c.ShortName)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnType("nvarchar");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(c => c.RS)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar");

            builder.Property(c => c.BankForRS)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnType("nvarchar");

            builder.Property(c => c.KS)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar");

            builder.Property(c => c.BIK)
                .IsRequired()
                .HasMaxLength(9)
                .HasColumnType("nvarchar");

            builder.Property(c => c.INN)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("nvarchar");

            builder.Property(c => c.KPP)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("nvarchar");

            builder.Property(c => c.OGRN)
                .IsRequired()
                .HasMaxLength(13)
                .HasColumnType("nvarchar");

            builder.Property(c => c.DocumentOfOrganisation)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar");


			builder.HasOne(i => i.Person)
                .WithOne(i => i.Organisation)
                .HasForeignKey<Organisation>(i => i.PersonId)
                .HasConstraintName("FK_Organisation_PersonId_Person_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
