using Hospital.Core.Domain.Models;

namespace Hospital.WebApplication.Mappers;

public static class AppointmentsMapper
{
    public static Appointment ToDomain(this AppointmentDto appointmentDto) => new()
    {
        AppointmentTime = appointmentDto.AppointmentTime,
        OfficeNumber = appointmentDto.OfficeNumber,
        IsRepeated = appointmentDto.IsRepeated,
        DoctorId = appointmentDto.DoctorId,
        PatientId = appointmentDto.PatientId
    };
}