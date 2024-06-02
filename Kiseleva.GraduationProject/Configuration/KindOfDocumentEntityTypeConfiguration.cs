using Kiseleva.GraduationProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiseleva.GraduationProject.Configuration
{
    public class KindOfDocumentEntityTypeConfiguration : IEntityTypeConfiguration<KindOfDocument>
    {
        public void Configure(EntityTypeBuilder<KindOfDocument> builder)
        {
            builder.HasKey(c => c.Id)
                .HasName("PK_KindOfDocument_Id");

            builder.Property(c => c.Kind)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

        }
    }
}
