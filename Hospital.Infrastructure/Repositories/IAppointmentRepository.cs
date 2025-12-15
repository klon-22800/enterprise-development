using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;

public interface IAppointmentRepository : IRepository<Appointment>
{
    public Task<List<Appointment>> GetByDoctorIdAsync(Guid doctorId);
    public Task<List<Appointment>> GetByPatientIdAsync(Guid patientId);
}
