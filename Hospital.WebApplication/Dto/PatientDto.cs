using Hospital.Core.Domain.Models.Enums;

public record PatientDto(
    string PassportNumber, 
    string Name,
    string Surname, 
    string? Patronymic,
    DateOnly BirthDate,
    string Address,
    Gender Gender,
    BloodType? BloodType, 
    RhesusFactor? RhesusFactor, 
    string PhoneNumber
    );