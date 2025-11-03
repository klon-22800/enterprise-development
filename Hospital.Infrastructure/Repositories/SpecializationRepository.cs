using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class SpecializationRepository(HospitalDbContext context) : IRepository<Specialization>
{
    public async Task<Guid> CreateAsync(Specialization entity)
    {
        context.Specializations.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<List<Specialization>> GetAllAsync()
    {
        return await context.Specializations
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Specialization?> GetByIdAsync(Guid id)
    {
        return await context.Specializations
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Specialization?> UpdateAsync(Guid id, Specialization entity)
    {
        var specialization = await context.Specializations.FindAsync(id);
        if (specialization == null) return null;

        specialization.Name = entity.Name;

        await context.SaveChangesAsync();
        return specialization;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var specialization = await context.Specializations.FindAsync(id);
        if (specialization == null) return false;

        context.Specializations.Remove(specialization);
        await context.SaveChangesAsync();
        return true;
    }
}
