using Hospital.Core.Domain.Models;

namespace Hospital.Core.Domain.Service;

public interface IAnalyticsService
{
    Task<List<Guid>> GetDoctorsWithExperienceOver10Async(CancellationToken cancellationToken = default);

    //Task<List<Patient>> GetPatientsByDoctorAsync(Guid doctorId, CancellationToken cancellationToken = default);
    //Task<List<(Guid PatientId, int Count)>> GetRepeatedAppointmentsLastMonthAsync(DateTime today, CancellationToken cancellationToken = default);
    //Task<List<Patient>> GetPatientsOver30WithMultipleDoctorsAsync(DateOnly today, CancellationToken cancellationToken = default);
    //Task<List<Appointment>> GetAppointmentsCurrentMonthByCabinetAsync(string cabinetNumber, DateTime today, CancellationToken cancellationToken = default);


}