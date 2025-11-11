using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Hospital.Core.Domain.Service;
using Microsoft.EntityFrameworkCore;

namespace Hospital.WebApplication.Services;

/// <summary>
/// Service for managing specializations.
/// </summary>
public class SpecializationService(IRepository<Specialization> repository) : ISpecializationService
{
    /// <summary>
    /// Creates a new specialization.
    /// </summary>
    /// <param name="name">The name of the specialization.</param>
    /// <returns>The ID of the created specialization.</returns>
    public async Task<Guid> CreateSpecializationAsync(string name)
    {
        try
        {
            return await repository.CreateAsync(new Specialization { Name = name });
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("Invalid data.");
        }
    }

    /// <summary>
    /// Returns all specializations.
    /// </summary>
    /// <returns>List of all specializations.</returns>
    public async Task<List<Specialization>> GetAllSpecializationsAsync() =>
        await repository.GetAllAsync();

    /// <summary>
    /// Returns a specialization by ID.
    /// </summary>
    /// <param name="id">The ID of the specialization.</param>
    /// <returns>The specialization with the specified ID, or <c>null</c> if not found.</returns>
    public async Task<Specialization?> GetSpecializationAsync(Guid id) =>
        await repository.GetByIdAsync(id);

    /// <summary>
    /// Updates an existing specialization.
    /// </summary>
    /// <param name="id">The ID of the specialization to update.</param>
    /// <param name="entity">The updated specialization data.</param>
    /// <returns>The updated specialization, or <c>null</c> if not found.</returns>
    public async Task<Specialization?> UpdateSpecializationAsync(Guid id, Specialization entity) =>
        await repository.UpdateAsync(id, entity);

    /// <summary>
    /// Deletes a specialization by ID.
    /// </summary>
    /// <param name="id">The ID of the specialization to delete.</param>
    /// <returns><c>true</c> if the specialization was deleted; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeleteSpecializationAsync(Guid id)
    {
        try
        {
            return await repository.DeleteAsync(id);
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("Cannot delete specialization because there are related doctor");
        }
    }
}