using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Hospital.Core.Domain.Service;

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
    public async Task<Guid> CreatePatientAsync(Patient patient) =>
        await repository.CreateAsync(patient);

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
    public async Task<Patient?> UpdatePatientAsync(Guid id, Patient patient) =>
        await repository.UpdateAsync(id, patient);

    /// <summary>
    /// Deletes a patient by ID.
    /// </summary>
    /// <param name="id">The ID of the patient to delete.</param>
    /// <returns><c>true</c> if the patient was deleted; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeletePatientAsync(Guid id) =>
        await repository.DeleteAsync(id);
}