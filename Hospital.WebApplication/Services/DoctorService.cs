using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Hospital.Core.Domain.Service;

namespace Hospital.WebApplication.Services;

public class DoctorService(IRepository<Doctor> repository) : IDoctorService
{
    public async Task<Guid> CreateDoctorAsync(Doctor doctor) =>
        await repository.CreateAsync(doctor);

    public async Task<List<Doctor>> GetAllDoctorsAsync() =>
        await repository.GetAllAsync();

    public async Task<Doctor?> GetDoctorAsync(Guid id) =>
        await repository.GetByIdAsync(id);

    public async Task<Doctor?> UpdateDoctorAsync(Guid id, Doctor doctor) =>
        await repository.UpdateAsync(id, doctor);

    public async Task<bool> DeleteDoctorAsync(Guid id) =>
        await repository.DeleteAsync(id);
}
