using Kiseleva.GraduationProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = Kiseleva.GraduationProject.Entities.File;
namespace Kiseleva.GraduationProject.Configuration
{
    public class FileEntityTypeConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasKey(f => f.Id)
                .HasName("PK_File_Id");

            builder.Property(f => f.FileName)
                .IsRequired()
                .HasColumnType("nvarchar");

            builder.Property(f => f.ContentType)
                .IsRequired()
                .HasColumnType("nvarchar");

            builder.Property(f => f.Data)
                .IsRequired()
                .HasColumnType("tinyint");

            builder.HasOne(f => f.Person)
                .WithMany(i => i.Files)
                .HasForeignKey(i => i.PersonId)
                .HasConstraintName("FK_Files_PersonId_Person_Id")
                .OnDelete(DeleteBehavior.NoAction);
    }
    }
}
