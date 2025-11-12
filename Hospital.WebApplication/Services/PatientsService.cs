using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Hospital.Core.Domain.Service;
using Microsoft.EntityFrameworkCore;

namespace Hospital.WebApplication.Services;

/// <summary>
/// Service for managing patients.
/// </summary>
public class PatientService(IRepository<Patient> repository) : IPatientService
{
    /// <summary>
    /// Creates a new patient.
    /// </summary>
    /// <param name="patient">The patient to create.</param>
    /// <returns>The ID of the created patient.</returns>
    public async Task<Guid> CreatePatientAsync(Patient patient)
    {
        try
        {
            return await repository.CreateAsync(patient);
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("Invalid data.");
        }
    }

    /// <summary>
    /// Returns all patients.
    /// </summary>
    /// <returns>List of all patients.</returns>
    public async Task<List<Patient>> GetAllPatientsAsync() =>
        await repository.GetAllAsync();

    /// <summary>
    /// Returns a patient by ID.
    /// </summary>
    /// <param name="id">The ID of the patient.</param>
    /// <returns>The patient with the specified ID, or <c>null</c> if not found.</returns>
    public async Task<Patient?> GetPatientAsync(Guid id) =>
        await repository.GetByIdAsync(id);

    /// <summary>
    /// Updates an existing patient.
    /// </summary>
    /// <param name="id">The ID of the patient to update.</param>
    /// <param name="patient">The updated patient data.</param>
    /// <returns>The updated patient, or <c>null</c> if not found.</returns>
    public async Task<Patient?> UpdatePatientAsync(Guid id, Patient patient)
    {
        try
        {
            patient.Id = id;
            return await repository.UpdateAsync(id, patient);
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("Invalid data.");
        }
    }

    /// <summary>
    /// Deletes a patient by ID.
    /// </summary>
    /// <param name="id">The ID of the patient to delete.</param>
    /// <returns><c>true</c> if the patient was deleted; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeletePatientAsync(Guid id)
    {
        try
        {
            return await repository.DeleteAsync(id);
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("Cannot delete patient because there are related appointments.");
        }
    }
}