using Hospital.Core.Domain.Models;

namespace Hospital.WebApplication.Mappers;


public static class DoctorsMapper
{
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
}
