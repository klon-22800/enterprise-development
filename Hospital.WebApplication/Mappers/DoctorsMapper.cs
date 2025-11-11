using Hospital.Core.Domain.Models;
using Hospital.Contracts.Dto;

namespace Hospital.WebApplication.Mappers;


/// <summary>
/// Provides mapping methods for doctors.
/// </summary>
public static class DoctorsMapper
{
    /// <summary>Converts an DoctortDto to an Doctor domain model.</summary>
    public static Doctor ToDomain(this DoctorDto doctorDto) => new()
    {
        PassportNumber = doctorDto.PassportNumber,
        Name = doctorDto.Name,
        Surname = doctorDto.Surname,
        Patronymic = doctorDto.Patronymic,
        BirthDate = doctorDto.BirthDate,
        SpecializationId = doctorDto.SpecializationId,
        Experience = doctorDto.Experience
    };

    public static DoctorResponseDto ToResponse(this Doctor doctor) => new(
        doctor.Id,
        doctor.PassportNumber,
        doctor.Name,
        doctor.Surname,
        doctor.Patronymic,
        doctor.BirthDate,
        doctor.SpecializationId,
        doctor.Experience
    );
}
