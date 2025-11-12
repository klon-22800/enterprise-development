using Hospital.Core.Domain.Models;
using Hospital.Contracts.Dto;

namespace Hospital.WebApplication.Mappers;

/// <summary>
/// Provides mapping methods for appointments.
/// </summary>
public static class AppointmentsMapper
{
    /// <summary>
    /// Converts an AppointmentDto to an Appointment domain model.
    /// </summary>
    public static Appointment ToDomain(this AppointmentDto appointmentDto) => new()
    {
        AppointmentTime = appointmentDto.AppointmentTime,
        OfficeNumber = appointmentDto.OfficeNumber,
        IsRepeated = appointmentDto.IsRepeated,
        DoctorId = appointmentDto.DoctorId,
        PatientId = appointmentDto.PatientId
    };
    /// <summary>
    /// Converts an Appointment to an AppointmentResponseDto.
    /// </summary>
    public static AppointmentResponseDto ToResponse(this Appointment appointment) => new(
        appointment.Id,
        appointment.AppointmentTime,
        appointment.OfficeNumber,
        appointment.IsRepeated,
        appointment.PatientId,
        appointment.DoctorId
    );

}