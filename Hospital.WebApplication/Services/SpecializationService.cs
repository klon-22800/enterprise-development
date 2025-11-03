using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Hospital.Core.Domain.Service;

namespace Hospital.WebApplication.Services;

public class SpecializationService(IRepository<Specialization> repository) : ISpecializationService
{
    public async Task<Guid> CreateSpecializationAsync(Specialization entity) =>
        await repository.CreateAsync(entity);

    public async Task<List<Specialization>> GetAllSpecializationsAsync() =>
        await repository.GetAllAsync();

    public async Task<Specialization?> GetSpecializationAsync(Guid id) =>
        await repository.GetByIdAsync(id);

    public async Task<Specialization?> UpdateSpecializationAsync(Guid id, Specialization entity) =>
        await repository.UpdateAsync(id, entity);

    public async Task<bool> DeleteSpecializationAsync(Guid id) =>
        await repository.DeleteAsync(id);
}
