using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Hospital.Core.Domain.Service;

namespace Hospital.WebApplication.Services;

/// <summary>
/// Service for managing doctors.
/// </summary>
public class DoctorService(IRepository<Doctor> repository) : IDoctorService
{
    /// <summary>
    /// Creates a new doctor.
    /// </summary>
    /// <param name="doctor">The doctor to create.</param>
    /// <returns>The ID of the created doctor.</returns>
    public async Task<Guid> CreateDoctorAsync(Doctor doctor) =>
        await repository.CreateAsync(doctor);

    /// <summary>
    /// Returns all doctors.
    /// </summary>
    /// <returns>List of all doctors.</returns>
    public async Task<List<Doctor>> GetAllDoctorsAsync() =>
        await repository.GetAllAsync();

    /// <summary>
    /// Returns a doctor by ID.
    /// </summary>
    /// <param name="id">The ID of the doctor.</param>
    /// <returns>The doctor with the specified ID, or <c>null</c> if not found.</returns>
    public async Task<Doctor?> GetDoctorAsync(Guid id) =>
        await repository.GetByIdAsync(id);

    /// <summary>
    /// Updates an existing doctor.
    /// </summary>
    /// <param name="id">The ID of the doctor to update.</param>
    /// <param name="doctor">The updated doctor data.</param>
    /// <returns>The updated doctor, or <c>null</c> if not found.</returns>
    public async Task<Doctor?> UpdateDoctorAsync(Guid id, Doctor doctor) =>
        await repository.UpdateAsync(id, doctor);

    /// <summary>
    /// Deletes a doctor by ID.
    /// </summary>
    /// <param name="id">The ID of the doctor to delete.</param>
    /// <returns><c>true</c> if the doctor was deleted; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeleteDoctorAsync(Guid id) =>
        await repository.DeleteAsync(id);
}
