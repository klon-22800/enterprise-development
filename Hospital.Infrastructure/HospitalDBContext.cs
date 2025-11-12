using Hospital.Core.Domain.DataSeeder;
using Hospital.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure;

public class HospitalDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().ToTable("doctors");
        modelBuilder.Entity<Specialization>().ToTable("specializations");
        modelBuilder.Entity<Patient>().ToTable("patients");
        modelBuilder.Entity<Appointment>().ToTable("appointments");

        modelBuilder.Entity<Doctor>()
            .HasOne(d => d.Specialization)
            .WithMany()
            .HasForeignKey(d => d.SpecializationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany()
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany()
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        var specialization = DataSeeder.SeedSpecializations();
        var doctors = DataSeeder.SeedDoctors(specialization);
        var patients = DataSeeder.SeedPatients();

        modelBuilder.Entity<Specialization>()
            .HasData(specialization);

        modelBuilder.Entity<Doctor>()
            .HasData(doctors);

        modelBuilder.Entity<Patient>()
            .HasData(patients);

        modelBuilder.Entity<Appointment>()
            .HasData(DataSeeder.SeedAppointments(patients, doctors));
        
    }
}
