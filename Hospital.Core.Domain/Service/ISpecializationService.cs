using Hospital.Core.Domain.Models;

namespace Hospital.Core.Domain.Service;


/// <summary>Interface for the specialization service.</summary>
public interface ISpecializationService
{
    /// <summary>Creates a new specialization.</summary>
    /// <param name="name">The name of the specialization.</param>
    /// <returns>The Id of the created specialization.</returns>
    public Task<Guid> CreateSpecializationAsync(string name);

    /// <summary>Returns all specializations.</summary>
    /// <returns>A list of all specializations.</returns>
    public Task<List<Specialization>> GetAllSpecializationsAsync();

    /// <summary>Returns a specialization by Id.</summary>
    /// <param name="id">The Id of the specialization.</param>
    /// <returns>The specialization with the specified Id, or <c>null</c> if not found.</returns>
    public Task<Specialization?> GetSpecializationAsync(Guid id);

    /// <summary>Updates a specialization.</summary>
    /// <param name="id">The Id of the specialization to update.</param>
    /// <param name="entity">The specialization data.</param>
    /// <returns>The updated specialization, or <c>null</c> if not found.</returns>
    public Task<Specialization?> UpdateSpecializationAsync(Guid id, Specialization entity);

    /// <summary>Deletes a specialization by Id.</summary>
    /// <param name="id">The Id of the specialization to delete.</param>
    /// <returns><c>true</c> if deleted; otherwise, <c>false</c>.</returns>
    public Task<bool> DeleteSpecializationAsync(Guid id);
}