namespace Hospital.Contracts.Dto;

/// <summary>
/// Data transfer object for an appointment.
/// </summary>
/// <param name="AppointmentTime">The date and time of the appointment.</param>
/// <param name="OfficeNumber">The office number where the appointment takes place.</param>
/// <param name="IsRepeated">Indicates whether the appointment is a repeated one.</param>
/// <param name="PatientId">The unique id of the patient.</param>
/// <param name="DoctorId">The unique id of the doctor.</param>
public record AppointmentDto(
    DateTime AppointmentTime,
    string OfficeNumber,
    bool IsRepeated,
    Guid PatientId,
    Guid DoctorId
);

public record AppointmentResponseDto(
    Guid Id,
    DateTime AppointmentTime,
    string OfficeNumber,
    bool IsRepeated,
    Guid PatientId,
    Guid DoctorId
);
