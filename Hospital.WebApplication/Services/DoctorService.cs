using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Service;
using Microsoft.EntityFrameworkCore;

namespace Hospital.WebApplication.Services;

/// <summary>
/// Service for managing doctors.
/// </summary>
public class DoctorService(IDoctorRepository repository) : IDoctorService
{
    /// <summary>
    /// Creates a new doctor.
    /// </summary>
    /// <param name="doctor">The doctor to create.</param>
    /// <returns>The ID of the created doctor.</returns>
    public async Task<Guid> CreateDoctorAsync(Doctor doctor)
    {
        try
        {
            return await repository.CreateAsync(doctor);
        }
        catch (DbUpdateException ex)
        {
            throw new InvalidOperationException("Specialization does not exist", ex);
        }
    }

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
    public async Task<Doctor?> UpdateDoctorAsync(Guid id, Doctor doctor)
    {
        try
        {
            return await repository.UpdateAsync(id, doctor);
        }
        catch (DbUpdateException ex)
        {
            throw new InvalidOperationException("Specialization does not exist", ex);
        }
    }

    /// <summary>
    /// Deletes a doctor by ID.
    /// </summary>
    /// <param name="id">The ID of the doctor to delete.</param>
    /// <returns><c>true</c> if the doctor was deleted; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeleteDoctorAsync(Guid id)
    {
        try
        {
            return await repository.DeleteAsync(id);
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("Cannot delete doctor because there are related appointments.");
        }
    }

    public async Task<List<Doctor>> GetDoctorsBySpecializationAsync(Guid specializationId) =>
        await repository.GetBySpecializationIdAsync(specializationId);

}
