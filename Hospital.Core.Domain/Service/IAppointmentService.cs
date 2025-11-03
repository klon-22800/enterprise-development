using Hospital.Core.Domain.Models;

namespace Hospital.Core.Domain.Service;

public interface IAppointmentService
{
    public Task<Guid> CreateAppointment(Appointment appointment);

    public Task<bool> DeletaAppointment(Guid guid);

    public Task<Appointment> GetAppointment(Guid guid);

    public Task<List<Appointment>> GetAllAppointemts();

    public Task<Appointment?> UpdateAppointemt(Guid guid, Appointment appointment);

}