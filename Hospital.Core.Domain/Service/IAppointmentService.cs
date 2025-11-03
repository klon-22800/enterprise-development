using Hospital.Core.Domain.Models;

namespace Hospital.Core.Domain.Service;

public interface IAppointmentService
{
    public Task<List<Appointment>> GetAllAppointmentsAsync();
    public Task<Appointment?> GetAppointmentAsync(Guid id);
    public Task<Guid> CreateAppointmentAsync(Appointment appointment);
    public Task<Appointment?> UpdateAppointmentAsync(Guid id, Appointment appointment);
    public Task<bool> DeleteAppointmentAsync(Guid id);
}
