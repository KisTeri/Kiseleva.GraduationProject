using Kiseleva.GraduationProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiseleva.GraduationProject.Configuration
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(c => c.Id)
               .HasName("PK_Person_Id");

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(c => c.MiddleName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(c => c.DateOfBirth)
                .HasColumnType("date");

            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(11)
                .HasColumnType("nvarchar");

            builder.Property(c => c.KindOfPerson)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(c => c.Position)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

        }
    }
}
