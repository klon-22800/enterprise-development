using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for managing doctors.
/// </summary>
public class DoctorRepository(HospitalDbContext context) : IRepository<Doctor>
{
    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(Doctor entity)
    {
        context.Doctors.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    /// <inheritdoc/>
    public async Task<List<Doctor>> GetAllAsync()
    {
        return await context.Doctors
            .Include(d => d.Specialization)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Doctor?> GetByIdAsync(Guid id)
    {
        return await context.Doctors
            .AsNoTracking()
            .Include(d => d.Specialization)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    /// <inheritdoc/>
    public async Task<Doctor?> UpdateAsync(Guid id, Doctor entity)
    {
        var existing = await context.Doctors.FindAsync(id);
        if (existing is null) return null;

        context.Entry(existing).CurrentValues.SetValues(entity);

        await context.SaveChangesAsync();

        return existing;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid id)
    {
        var doctor = await context.Doctors.FindAsync(id);
        if (doctor == null) return false;

        context.Doctors.Remove(doctor);
        await context.SaveChangesAsync();
        return true;
    }
}
