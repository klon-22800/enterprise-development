using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

/// <summary>Repository implementation for managing patients.</summary>
public class PatientRepository(HospitalDbContext context) : IRepository<Patient>
{
    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(Patient entity)
    {
        context.Patients.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    /// <inheritdoc/>
    public async Task<List<Patient>> GetAllAsync()
    {
        return await context.Patients.AsNoTracking().ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Patient?> GetByIdAsync(Guid id)
    {
        return await context.Patients
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    /// <inheritdoc/>
    public async Task<Patient?> UpdateAsync(Guid id, Patient entity)
    {
        var existing = await context.Patients.FindAsync(id);
        if (existing is null) return null;

        context.Entry(existing).CurrentValues.SetValues(entity);

        await context.SaveChangesAsync();
        return existing;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid id)
    {
        var patient = await context.Patients.FindAsync(id);
        if (patient == null) return false;

        context.Patients.Remove(patient);
        await context.SaveChangesAsync();
        return true;
    }
}
