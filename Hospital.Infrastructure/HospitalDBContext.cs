using Hospital.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure;

public class HospitalDbContext(DbContextOptions options) : DbContext(options)
{

    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().ToTable("doctors");
        modelBuilder.Entity<Specialization>().ToTable("specializations");
    }
}
