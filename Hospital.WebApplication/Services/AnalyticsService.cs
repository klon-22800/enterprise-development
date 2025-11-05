using Hospital.Core.Domain.Service;
using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;

namespace Hospital.WebApplication.Services;

/// <summary>
/// Provides analytical queries for doctors, patients, and appointments.
/// </summary>
public class AnalyticsService(
    IRepository<Specialization> specializationRepository,
    IRepository<Doctor> doctorRepository,
    IRepository<Patient> patientRepository,
    IRepository<Appointment> appointmentRepository) : IAnalyticsService
{
    /// <summary>
    /// Returns doctors with 10 or more years of experience.
    /// </summary>
    public async Task<List<Guid>> GetDoctorsWithExperienceOver10Async(CancellationToken cancellationToken = default)
    {
        var doctors = await doctorRepository.GetAllAsync();

        var result = doctors
            .Where(d => d.Experience >= 10)
            .OrderBy(d => d.Id)
            .Select(d => d.Id)
            .ToList();

        return result;
    }

    /// <summary>
    /// Returns patients of a specific doctor, ordered by name.
    /// </summary>
    public async Task<List<Patient>> GetPatientsByDoctorAsync(Guid doctorId, CancellationToken cancellationToken = default)
    {
        var appointments = await appointmentRepository.GetAllAsync();
        var patients = await patientRepository.GetAllAsync();

        var result = appointments
            .Where(a => a.DoctorId == doctorId) 
            .Select(a => patients.First(p => p.Id == a.PatientId)) 
            .OrderBy(p => p.Surname)
            .ThenBy(p => p.Name)
            .ThenBy(p => p.Patronymic)
            .ToList();

        return result;
    }

    /// <summary>
    /// Returns repeated appointments per patient in the last month.
    /// </summary>
    public async Task<List<(Guid PatientId, int Count)>> GetRepeatedAppointmentsLastMonthAsync(DateTime today, CancellationToken cancellationToken = default)
    {
        var appointments = await appointmentRepository.GetAllAsync();

        var monthAgo = today.AddMonths(-1);

        var result = appointments
            .Where(a => a.IsRepeated && a.AppointmentTime >= monthAgo && a.AppointmentTime <= today)
            .GroupBy(a => a.PatientId) 
            .Select(g => (PatientId: g.Key, Count: g.Count()))
            .OrderBy(x => x.PatientId)
            .ToList();

        return result;
    }

    /// <summary>
    /// Returns patients over 30 years old who have appointments with multiple doctors.
    /// </summary>
    public async Task<List<Guid>> GetPatientsOver30WithMultipleDoctorsAsync(DateOnly today, CancellationToken cancellationToken = default)
    {
        var appointments = await appointmentRepository.GetAllAsync();
        var patients = await patientRepository.GetAllAsync();

        var ageLimit = today.AddYears(-30);

        var result = appointments
            .Join(patients,
                a => a.PatientId,
                p => p.Id,
                (a, p) => new { Appointment = a, Patient = p })
            .Where(x => x.Patient.BirthDate <= ageLimit)
            .GroupBy(x => x.Patient.Id)
            .Where(g => g.Select(x => x.Appointment.DoctorId).Distinct().Count() > 1)
            .Select(g => g.Key)
            .OrderBy(id => patients.First(p => p.Id == id).BirthDate)
            .ToList();

        return result;
    }

    /// <summary>
    /// Returns appointments in the current month for a specific cabinet.
    /// </summary>
    public async Task<List<Appointment>> GetAppointmentsCurrentMonthByCabinetAsync(string cabinetNumber, DateTime today, CancellationToken cancellationToken = default)
    {
        var appointments = await appointmentRepository.GetAllAsync();

        var result = appointments
            .Where(a => a.OfficeNumber == cabinetNumber
                        && a.AppointmentTime.Year == today.Year
                        && a.AppointmentTime.Month == today.Month)
            .OrderBy(a => a.AppointmentTime)
            .ToList();

        return result;
    }
}
