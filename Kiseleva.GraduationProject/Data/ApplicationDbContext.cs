using Kiseleva.GraduationProject.Entities;
using Kiseleva.GraduationProject.Helper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using File = Kiseleva.GraduationProject.Entities.File;

namespace Kiseleva.GraduationProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer().AddInterceptors(new SoftDeleteInterceptor());

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<Contract>()
                .HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<DocumentOfPerson>()
                .HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<KindOfDocument>()
                .HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<KindOfEducation>()
                .HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<Organisation>()
                .HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<Person>()
                .HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<ProgramOfEducation>()
                .HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<File>()
                .HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<CZN>()
                .HasQueryFilter(x => x.IsDeleted == false);
        }


        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
		{
			base.ConfigureConventions(builder);

			builder.Properties<DateOnly>()
		        .HaveConversion<DateOnlyConverter2, DateOnlyComparer>()
		        .HaveColumnType("date");
		}

		public DbSet<Address> Addresses { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<DocumentOfPerson> DocumentsOfPerson { get; set; }
        public DbSet<KindOfDocument> KindOfDocuments { get; set; }
        public DbSet<KindOfEducation> KindOfEducations { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ProgramOfEducation> ProgramOfEducations { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<CZN> CZNs { get; set; }

    }
}
