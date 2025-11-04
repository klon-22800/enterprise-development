using Hospital.Core.Domain.Models;

namespace Hospital.WebApplication.Mappers;

public static class PatientsMapper
{
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
}
