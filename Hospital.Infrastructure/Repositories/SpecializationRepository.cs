using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for managing specializations.
/// </summary>
public class SpecializationRepository(HospitalDbContext context) : IRepository<Specialization>
{
    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(Specialization entity)
    {
        context.Specializations.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    /// <inheritdoc/>
    public async Task<List<Specialization>> GetAllAsync()
    {
        return await context.Specializations
            .AsNoTracking()
            .ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Specialization?> GetByIdAsync(Guid id)
    {
        return await context.Specializations
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    /// <inheritdoc/>
    public async Task<Specialization?> UpdateAsync(Guid id, Specialization entity)
    {
        var specialization = await context.Specializations.FindAsync(id);
        if (specialization == null) return null;

        specialization.Name = entity.Name;

        await context.SaveChangesAsync();
        return specialization;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid id)
    {
        var specialization = await context.Specializations.FindAsync(id);
        if (specialization == null) return false;

        context.Specializations.Remove(specialization);
        await context.SaveChangesAsync();
        return true;
    }
}
