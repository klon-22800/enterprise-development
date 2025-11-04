public record AppointmentDto(
    DateTime AppointmentTime,
    string OfficeNumber,
    bool IsRepeated,
    Guid PatientId,
    Guid DoctorId
    );