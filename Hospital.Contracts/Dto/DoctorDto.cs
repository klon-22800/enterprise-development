namespace Hospital.Contracts.Dto;

/// <summary>
/// Data transfer object for a doctor.
/// </summary>
/// <param name="PassportNumber">The passport number of the doctor.</param>
/// <param name="Name">The first name of the doctor.</param>
/// <param name="Surname">The surname of the doctor.</param>
/// <param name="Patronymic">The patronymic of the doctor, if exist.</param>
/// <param name="BirthDate">The birth date of the doctor.</param>
/// <param name="SpecializationId">The unique id of the doctor's specialization.</param>
/// <param name="Experience">The number of years of experience.</param>
public record DoctorDto(
    string PassportNumber,
    string Name, 
    string Surname, 
    string? Patronymic,
    DateOnly BirthDate,
    Guid SpecializationId,
    int Experience
    );

public record DoctorResponseDto(
    Guid Id,
    string PassportNumber,
    string Name,
    string Surname,
    string? Patronymic,
    DateOnly BirthDate,
    Guid SpecializationId,
    int Experience
);