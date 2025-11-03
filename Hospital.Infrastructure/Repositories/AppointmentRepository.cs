using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class AppointmentRepository(HospitalDbContext context) : IRepository<Appointment>
{

    public async Task<List<Appointment>> GetAllAsync()
        => await context.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .ToListAsync();

    public async Task<Appointment?> GetByIdAsync(Guid id)
        => await context.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<Guid> CreateAsync(Appointment entity)
    {
        await context.Appointments.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<Appointment?> UpdateAsync(Guid id, Appointment entity)
    {
        var existing = await context.Appointments.FindAsync(id);
        if (existing is null) return null;

        context.Entry(existing).CurrentValues.SetValues(entity);
        await context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await context.Appointments.FindAsync(id);
        if (entity is null) return false;

        context.Appointments.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}
