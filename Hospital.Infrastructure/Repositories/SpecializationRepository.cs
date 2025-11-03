using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class SpecializationRepository(HospitalDbContext context) : IRepository<Specialization>
{
    private readonly HospitalDbContext _context = context;

    public async Task<Guid> CreateAsync(Specialization entity)
    {
        _context.Specializations.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<List<Specialization>> GetAllAsync()
    {
        return await _context.Specializations
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Specialization?> GetByIdAsync(Guid id)
    {
        return await _context.Specializations
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Specialization?> UpdateAsync(Guid id, Specialization entity)
    {
        var specialization = await _context.Specializations.FindAsync(id);
        if (specialization == null) return null;

        specialization.Name = entity.Name;

        await _context.SaveChangesAsync();
        return specialization;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var specialization = await _context.Specializations.FindAsync(id);
        if (specialization == null) return false;

        _context.Specializations.Remove(specialization);
        await _context.SaveChangesAsync();
        return true;
    }
}
