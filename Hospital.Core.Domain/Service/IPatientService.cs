using Hospital.Core.Domain.Models;

namespace Hospital.Core.Domain.Service;

/// <summary>Interface for the patient service.</summary>
public interface IPatientService
{
    /// <summary>Creates a new patient.</summary>
    /// <param name="patient">The patient to create.</param>
    /// <returns>The Id of the created patient.</returns>
    public Task<Guid> CreatePatientAsync(Patient patient);

    /// <summary>Returns all patients.</summary>
    /// <returns>A list of all patients.</returns>
    public Task<List<Patient>> GetAllPatientsAsync();

    /// <summary>Returns a patient by Id.</summary>
    /// <param name="id">The Id of the patient.</param>
    /// <returns>The patient with the specified Id, or <c>null</c> if not found.</returns>
    public Task<Patient?> GetPatientAsync(Guid id);

    /// <summary>Updates a patient.</summary>
    /// <param name="id">The Id of the patient to update.</param>
    /// <param name="patient">The patient data.</param>
    /// <returns>The updated patient, or <c>null</c> if not found.</returns>
    public Task<Patient?> UpdatePatientAsync(Guid id, Patient patient);

    /// <summary>Deletes a patient by Id.</summary>
    /// <param name="id">The Id of the patient to delete.</param>
    /// <returns><c>true</c> if deleted; otherwise, <c>false</c>.</returns>
    public Task<bool> DeletePatientAsync(Guid id);
}