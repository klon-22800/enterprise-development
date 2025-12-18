using  Hospital.Core.Domain.Shared.Enums;

namespace Hospital.Contracts.Dto.Patient;

/// <summary>
/// Data transfer object for a patient.
/// </summary>
/// <param name="PassportNumber">The passport number of the patient.</param>
/// <param name="Name">The first name of the patient.</param>
/// <param name="Surname">The surname of the patient.</param>
/// <param name="Patronymic">The patronymic of the patient, if exist.</param>
/// <param name="BirthDate">The birth date of the patient.</param>
/// <param name="Address">The home address of the patient.</param>
/// <param name="Gender">The gender of the patient.</param>
/// <param name="BloodType">The blood type of the patient, if known.</param>
/// <param name="RhesusFactor">The Rhesus factor of the patient, if known.</param>
/// <param name="PhoneNumber">The contact phone number of the patient.</param>


public record PatientResponseDto(
    Guid Id,
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