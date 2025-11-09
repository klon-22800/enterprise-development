using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

/// <summary>Repository implementation for managing appointments.</summary>
public class AppointmentRepository(HospitalDbContext context) : IRepository<Appointment>
{
    /// <inheritdoc/>
    public async Task<List<Appointment>> GetAllAsync()
        => await context.Appointments
            .AsNoTracking()
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .ToListAsync();

    /// <inheritdoc/>
    public async Task<Appointment?> GetByIdAsync(Guid id)
        => await context.Appointments
            .AsNoTracking()
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .FirstOrDefaultAsync(a => a.Id == id);

    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(Appointment entity)
    {
        await context.Appointments.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    /// <inheritdoc/>
    public async Task<Appointment?> UpdateAsync(Guid id, Appointment entity)
    {
        var existing = await context.Appointments.FindAsync(id);
        if (existing is null) return null;

        context.Entry(existing).CurrentValues.SetValues(entity);
        await context.SaveChangesAsync();
        return existing;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await context.Appointments.FindAsync(id);
        if (entity is null) return false;

        context.Appointments.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}