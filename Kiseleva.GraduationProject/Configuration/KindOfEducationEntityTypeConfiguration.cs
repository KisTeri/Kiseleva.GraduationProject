using Kiseleva.GraduationProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiseleva.GraduationProject.Configuration
{
    public class KindOfEducationEntityTypeConfiguration : IEntityTypeConfiguration<KindOfEducation>
    {
        public void Configure(EntityTypeBuilder<KindOfEducation> builder)
        {
            builder.HasKey(c => c.Id)
                .HasName("PK_KindOfEducation_Id");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

        }
    }
}
