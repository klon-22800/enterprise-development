using Hospital.Core.Domain.Models;

namespace Hospital.WebApplication.Mappers;

/// <summary>
/// Provides mapping methods for appointments.
/// </summary>
public static class AppointmentsMapper
{
    /// <summary>Converts an AppointmentDto to an Appointment domain model.</summary>
    public static Appointment ToDomain(this AppointmentDto appointmentDto) => new()
    {
        AppointmentTime = appointmentDto.AppointmentTime,
        OfficeNumber = appointmentDto.OfficeNumber,
        IsRepeated = appointmentDto.IsRepeated,
        DoctorId = appointmentDto.DoctorId,
        PatientId = appointmentDto.PatientId
    };
}