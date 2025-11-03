using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class PatientRepository(HospitalDbContext context) : IRepository<Patient>
{
    public async Task<Guid> CreateAsync(Patient entity)
    {
        context.Patients.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<List<Patient>> GetAllAsync()
    {
        return await context.Patients.AsNoTracking().ToListAsync();
    }

    public async Task<Patient?> GetByIdAsync(Guid id)
    {
        return await context.Patients.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Patient?> UpdateAsync(Guid id, Patient entity)
    {
        var patient = await context.Patients.FindAsync(id);
        if (patient == null) return null;

        patient.PassportNumber = entity.PassportNumber;
        patient.Name = entity.Name;
        patient.Surname = entity.Surname;
        patient.Patronymic = entity.Patronymic;
        patient.BirthDate = entity.BirthDate;
        patient.Address = entity.Address;
        patient.Gender = entity.Gender;
        patient.BloodType = entity.BloodType;
        patient.RhesusFactor = entity.RhesusFactor;
        patient.PhoneNumber = entity.PhoneNumber;

        await context.SaveChangesAsync();
        return patient;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var patient = await context.Patients.FindAsync(id);
        if (patient == null) return false;

        context.Patients.Remove(patient);
        await context.SaveChangesAsync();
        return true;
    }
}
