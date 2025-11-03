using Hospital.Core.Domain.Models;

namespace Hospital.Core.Domain.Service;

public interface IPatientService
{
    public Task<Guid> CreatePatientAsync(Patient patient);
    public Task<List<Patient>> GetAllPatientsAsync();
    public Task<Patient?> GetPatientAsync(Guid id);
    public Task<Patient?> UpdatePatientAsync(Guid id, Patient patient);
    public Task<bool> DeletePatientAsync(Guid id);
}
