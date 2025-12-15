using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;

public interface IDoctorRepository : IRepository<Doctor>
{
    public Task<List<Doctor>> GetBySpecializationIdAsync(Guid specializationId);
}
