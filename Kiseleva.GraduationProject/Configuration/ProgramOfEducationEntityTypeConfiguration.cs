using Kiseleva.GraduationProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiseleva.GraduationProject.Configuration
{
    public class ProgramOfEducationEntityTypeConfiguration : IEntityTypeConfiguration<ProgramOfEducation>
    {
        public void Configure(EntityTypeBuilder<ProgramOfEducation> builder)
        {
            builder.HasKey(c => c.Id)
               .HasName("PK_DocumentOfPerson_Id");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(c => c.Price)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.Property(c => c.PriceInWords)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("nvarchar");

            builder.Property(c => c.HoursAmount)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnType("nvarchar");

            builder.Property(c => c.EducationLength)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.HasOne(i => i.KindOfEducation)
                .WithMany(i => i.ProgramsOfEducation)
                .HasForeignKey(i => i.KindOfEducation)
                .HasConstraintName("FK_ProgramsOfEducation_KindOfEducationId_KindOfEducation_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
