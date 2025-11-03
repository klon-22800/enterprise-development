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

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
