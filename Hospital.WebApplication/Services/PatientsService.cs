using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Hospital.Core.Domain.Service;

namespace Hospital.WebApplication.Services;

public class PatientService(IRepository<Patient> repository) : IPatientService
{
    public async Task<Guid> CreatePatientAsync(Patient patient) =>
        await repository.CreateAsync(patient);

    public async Task<List<Patient>> GetAllPatientsAsync() =>
        await repository.GetAllAsync();

    public async Task<Patient?> GetPatientAsync(Guid id) =>
        await repository.GetByIdAsync(id);

    public async Task<Patient?> UpdatePatientAsync(Guid id, Patient patient) =>
        await repository.UpdateAsync(id, patient);

    public async Task<bool> DeletePatientAsync(Guid id) =>
        await repository.DeleteAsync(id);
}
