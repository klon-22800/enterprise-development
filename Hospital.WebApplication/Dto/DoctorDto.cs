public record DoctorDto(
    string PassportNumber,
    string Name, 
    string Surname, 
    string? Patronymic,
    DateOnly BirthDate,
    Guid SpecializationId,
    int Experience
    );