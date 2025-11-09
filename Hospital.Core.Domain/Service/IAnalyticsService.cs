using Hospital.Core.Domain.Models;

namespace Hospital.Core.Domain.Service;

/// <summary>Interface for the analytics service.</summary>
public interface IAnalyticsService
{
    /// <summary>Returns IDs of doctors with more than 10 years of experience.</summary>
    public Task<List<Guid>> GetDoctorsWithExperienceOver10Async(CancellationToken cancellationToken = default);

    /// <summary>Returns all patients assigned to a specific doctor.</summary>
    public Task<List<Patient>> GetPatientsByDoctorAsync(Guid doctorId, CancellationToken cancellationToken = default);

    /// <summary>Returns patients with repeated appointments in the last month.</summary>
    public Task<List<(Guid PatientId, int Count)>> GetRepeatedAppointmentsLastMonthAsync(DateTime today, CancellationToken cancellationToken = default);

    /// <summary>Returns patients over 30 who have appointments with multiple doctors.</summary>
    public Task<List<Guid>> GetPatientsOver30WithMultipleDoctorsAsync(DateOnly today, CancellationToken cancellationToken = default);

    /// <summary>Returns all appointments for a specific cabinet in the current month.</summary>
    public Task<List<Appointment>> GetAppointmentsCurrentMonthByCabinetAsync(string officeNumber, DateTime today, CancellationToken cancellationToken = default);
}