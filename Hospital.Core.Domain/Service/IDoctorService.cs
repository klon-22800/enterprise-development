using Hospital.Core.Domain.Models;

namespace Hospital.Core.Domain.Service;
public interface IDoctorService
{
    public Task<Guid> CreateDoctorAsync(Doctor doctor);

    public Task<bool> DeleteDoctorAsync(Guid guid);

    public Task<Doctor?> GetDoctorAsync(Guid guid);

    public Task<List<Doctor>> GetAllDoctorsAsync();

    public Task<Doctor?> UpdateDoctorAsync(Guid guid, Doctor doctor);
}
