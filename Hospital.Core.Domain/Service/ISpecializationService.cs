using Hospital.Core.Domain.Models;

namespace Hospital.Core.Domain.Service;

public interface ISpecializationService
{
    public Task<Guid> CreateSpecializationAsync(Specialization entity);
    public Task<List<Specialization>> GetAllSpecializationsAsync();
    public Task<Specialization?> GetSpecializationAsync(Guid id);
    public Task<Specialization?> UpdateSpecializationAsync(Guid id, Specialization entity);
    public Task<bool> DeleteSpecializationAsync(Guid id);
}
