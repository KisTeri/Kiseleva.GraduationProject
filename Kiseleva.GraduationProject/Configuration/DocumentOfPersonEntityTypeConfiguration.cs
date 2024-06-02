using Kiseleva.GraduationProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiseleva.GraduationProject.Configuration
{
    public class DocumentOfPersonEntityTypeConfiguration : IEntityTypeConfiguration<DocumentOfPerson>
    {
        public void Configure(EntityTypeBuilder<DocumentOfPerson> builder)
        {
            builder.HasKey(c => c.Id)
               .HasName("PK_DocumentOfPerson_Id");

            builder.Property(c => c.Series)
                .IsRequired()
                .HasMaxLength(4)
                .HasColumnType("nvarchar");

            builder.Property(c => c.Number)
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnType("nvarchar");

            builder.Property(c => c.IssuedBy)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(c => c.IssuedWhen)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("nvarchar");

            builder.HasOne(i => i.Person)
            .WithMany(i => i.DocumentsOfPerson)
            .HasForeignKey(i => i.Person)
            .HasConstraintName("FK_DocumentsOfPerson_PersonId_Person_Id")
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.KindOfDocument)
            .WithMany(i => i.DocumentsOfPerson)
            .HasForeignKey(i => i.KindOfDocument)
            .HasConstraintName("FK_DocumentsOfPerson_KindOfDocumentId_KindOfDocument_Id")
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
