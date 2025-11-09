using Hospital.Core.Domain.Models;

namespace Hospital.Core.Domain.Service;

/// <summary>Interface for the appointment service.</summary>
public interface IAppointmentService
{
    /// <summary>Returns all appointments.</summary>
    public Task<List<Appointment>> GetAllAppointmentsAsync();

    /// <summary>Returns an appointment by Id.</summary>
    /// <param name="id">The Id of the appointment.</param>
    /// <returns>The appointment with the specified Id, or <c>null</c> if not found.</returns>
    public Task<Appointment?> GetAppointmentAsync(Guid id);

    /// <summary>Creates a new appointment.</summary>
    /// <param name="appointment">The appointment to create.</param>
    /// <returns>The Id of the created appointment.</returns>
    public Task<Guid> CreateAppointmentAsync(Appointment appointment);

    /// <summary>Updates an appointment.</summary>
    /// <param name="id">The Id of the appointment to update.</param>
    /// <param name="appointment">The appointment data.</param>
    /// <returns>The updated appointment, or <c>null</c> if not found.</returns>
    public Task<Appointment?> UpdateAppointmentAsync(Guid id, Appointment appointment);

    /// <summary>Deletes an appointment by Id.</summary>
    /// <param name="id">The Id of the appointment to delete.</param>
    /// <returns><c>true</c> if deleted; otherwise, <c>false</c>.</returns>
    public Task<bool> DeleteAppointmentAsync(Guid id);
}