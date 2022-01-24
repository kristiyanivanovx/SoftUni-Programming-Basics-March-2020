using HospitalDatabase.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalDatabase.Data
{
    class HospitalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Hospital;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>()
                .HasKey(x => new { x.PatientId, x.MedicamentId });
        }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
         
        public DbSet<Medicament> Medicaments { get; set; }
         
        public DbSet<Patient> Patients { get; set; }
         
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }
    }
}
