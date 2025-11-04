using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class DoctorRepository(HospitalDbContext context) : IRepository<Doctor>
{
    public async Task<Guid> CreateAsync(Doctor entity)
    {
        context.Doctors.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<List<Doctor>> GetAllAsync()
    {
        return await context.Doctors
            .Include(d => d.Specialization)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Doctor?> GetByIdAsync(Guid id)
    {
        return await context.Doctors
            .Include(d => d.Specialization)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Doctor?> UpdateAsync(Guid id, Doctor entity)
    {
        var doctor = await context.Doctors.FindAsync(id);
        if (doctor == null) return null;

        doctor.PassportNumber = entity.PassportNumber;
        doctor.Name = entity.Name;
        doctor.Surname = entity.Surname;
        doctor.Patronymic = entity.Patronymic;
        doctor.BirthDate = entity.BirthDate;
        doctor.Specialization = entity.Specialization;
        doctor.Experience = entity.Experience;

        await context.SaveChangesAsync();
        return doctor;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var doctor = await context.Doctors.FindAsync(id);
        if (doctor == null) return false;

        context.Doctors.Remove(doctor);
        await context.SaveChangesAsync();
        return true;
    }
}
