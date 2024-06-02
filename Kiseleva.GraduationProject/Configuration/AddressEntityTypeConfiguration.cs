using Kiseleva.GraduationProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiseleva.GraduationProject.Configuration
{
    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(c => c.Id)
                .HasName("PK_Address_Id");

            builder.Property(c => c.Region)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(c => c.District)
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(c => c.Settlement)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(c => c.Street)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(c => c.Building)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("nvarchar");

            builder.Property(c => c.Apartment)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("nvarchar");

            builder.Property(c => c.Index)
                .HasMaxLength(6)
                .HasColumnType("nvarchar");

            builder.Property(c => c.KindOfAddress)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.HasOne(i => i.Organisation)
                .WithMany(i => i.Addresses)
                .HasForeignKey(i => i.Organisation)
                .HasConstraintName("FK_Addresses_OrganisationId_Organisation_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.Person)
                .WithOne(i => i.Address)
                .HasForeignKey<Address>(i => i.Person)
                .HasConstraintName("FK_Addresses_PersonId_Person_Id")
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
