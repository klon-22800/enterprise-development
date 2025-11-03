using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Hospital.Core.Domain.Service;

namespace Hospital.WebApplication.Services;

public class AppointmentService(IRepository<Appointment> repository) : IAppointmentService
{
    public async Task<Guid> CreateAppointmentAsync(Appointment appointment) =>
        await repository.CreateAsync(appointment);

    public async Task<List<Appointment>> GetAllAppointmentsAsync() =>
        await repository.GetAllAsync();

    public async Task<Appointment?> GetAppointmentAsync(Guid id) =>
        await repository.GetByIdAsync(id);

    public async Task<Appointment?> UpdateAppointmentAsync(Guid id, Appointment appointment) =>
        await repository.UpdateAsync(id, appointment);

    public async Task<bool> DeleteAppointmentAsync(Guid id) =>
        await repository.DeleteAsync(id);
}
