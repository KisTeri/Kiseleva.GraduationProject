using Kiseleva.GraduationProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiseleva.GraduationProject.Configuration
{
    public class CZNEntityTypeConfiguration : IEntityTypeConfiguration<CZN>
    {
        public void Configure(EntityTypeBuilder<CZN> builder)
        {
            builder.HasKey(c => c.Id)
                .HasName("PK_CZN_Id");

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(c => c.ShortName)
                .HasMaxLength(70)
                .HasColumnType("nvarchar");

            builder.Property(c => c.Email)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(c => c.RS)
                .HasMaxLength(20)
                .HasColumnType("nvarchar");

            builder.Property(c => c.BankForRS)
                .HasMaxLength(250)
                .HasColumnType("nvarchar");

            builder.Property(c => c.KS)
                .HasMaxLength(20)
                .HasColumnType("nvarchar");

            builder.Property(c => c.BIK)
                .HasMaxLength(9)
                .HasColumnType("nvarchar");

            builder.Property(c => c.INN)
                .HasMaxLength(10)
                .HasColumnType("nvarchar");

            builder.Property(c => c.KPP)
                .HasMaxLength(10)
                .HasColumnType("nvarchar");

            builder.Property(c => c.OGRN)
                .HasMaxLength(13)
                .HasColumnType("nvarchar");

            builder.Property(c => c.DocumentOfOrganisation)
                .HasMaxLength(200)
                .HasColumnType("nvarchar");

			builder.HasOne(i => i.Person)
                .WithOne(i => i.CZN)
                .HasForeignKey<CZN>(i => i.PersonId)
                .HasConstraintName("FK_CZN_PersonId_Person_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
