using Kiseleva.GraduationProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiseleva.GraduationProject.Configuration
{
    public class ContractEntityTypeConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(c => c.Id)
                .HasName("PK_Contract_Id");

            builder.Property(c => c.Number)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar");

            builder.Property(c => c.DateOfSigning)
                .IsRequired()
                .HasColumnType("date");

            //builder.Property(c => c.ValidityPeriod) 
            //    .IsRequired()
            //    .HasMaxLength(20)
            //    .HasColumnType("nvarchar");

            builder.Property(c => c.DateOfBeginning)
                .IsRequired()
                .HasColumnType("date");

            //builder.Property(c => c.DateOfEnding)
            //    .IsRequired()
            //    .HasColumnType("date");

            //builder.Property(c => c.SigningBody)
            //    .IsRequired()
            //    .HasMaxLength(50)
            //    .HasColumnType("nvarchar");

            //builder.HasOne(i => i.Organisation)
            //    .WithOne(i => i.Contract)
            //    .HasForeignKey<Contract>(i => i.OrganisationId)
            //    .HasConstraintName("FK_Contracts_OrganisationId_Organisation_Id")
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.ProgramOfEducation)
                .WithMany(i => i.Contracts)
                .HasForeignKey(i => i.ProgramOfEducationId)
                .HasConstraintName("FK_Contracts_ProgramOfEducationId_ProgramOfEducation_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.Person)
                .WithMany(i => i.Contracts)
                .HasForeignKey(i => i.PersonId)
                .HasConstraintName("FK_Contracts_PersonId_Person_Id")
                .OnDelete(DeleteBehavior.NoAction); // изменила с NoAction на Cascade
        }
    }
}
