using Hospital.Core.Domain.Models;
using Hospital.Contracts.Dto.Patient;

namespace Hospital.WebApplication.Mappers;

/// <summary>
/// Provides mapping methods for Patients.
/// </summary>
public static class PatientsMapper
{
    /// <summary>
    /// Converts an PatientDto to an Patient domain model.
    /// </summary>
    public static Patient ToDomain(this PatientDto patientDto) => new()
    {
        PassportNumber = patientDto.PassportNumber,
        Name = patientDto.Name,
        Surname = patientDto.Surname,
        Patronymic = patientDto.Patronymic,
        BirthDate = patientDto.BirthDate,
        Address = patientDto.Address,
        Gender = patientDto.Gender,
        BloodType = patientDto.BloodType,
        RhesusFactor = patientDto.RhesusFactor,
        PhoneNumber = patientDto.PhoneNumber
    };

    /// <summary>
    /// Converts an Patient to an PatientResponseDto.
    /// </summary>
    public static PatientResponseDto ToResponse(this Patient patient) => new(
        patient.Id,
        patient.PassportNumber,
        patient.Name,
        patient.Surname,
        patient.Patronymic,
        patient.BirthDate,
        patient.Address,
        patient.Gender,
        patient.BloodType,
        patient.RhesusFactor,
        patient.PhoneNumber
    );
}
