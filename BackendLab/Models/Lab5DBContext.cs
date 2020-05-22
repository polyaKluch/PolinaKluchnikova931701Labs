using BackendLab.Models;
using Microsoft.EntityFrameworkCore;

namespace WebBackLab1.Models
{
    public class Lab5DBContext : DbContext
    {
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Lab> Labs { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

        public Lab5DBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=dbLab5;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasSequence<int>("Doctorid").IncrementsBy(1);
            modelBuilder.HasSequence<int>("Labid").IncrementsBy(1);
            modelBuilder.HasSequence<int>("Hospitalid").IncrementsBy(1);
            modelBuilder.HasSequence<int>("Patientid").IncrementsBy(1);

            modelBuilder.Entity<Doctor>()
                        .Property(o => o.Id)
                        .HasDefaultValueSql("NEXT VALUE FOR Doctorid");

            modelBuilder.Entity<Hospital>()
                        .Property(o => o.Id)
                        .HasDefaultValueSql("NEXT VALUE FOR Hosid");

            modelBuilder.Entity<Lab>()
                        .Property(o => o.Id)
                        .HasDefaultValueSql("NEXT VALUE FOR Hospitalid");

            modelBuilder.Entity<Patient>()
                        .Property(o => o.Id)
                        .HasDefaultValueSql("NEXT VALUE FOR Patientid");


        }
    }
}
