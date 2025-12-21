using Hospital.Core.Domain.Models;
using Hospital.Grpc.Contracts;

namespace Hospital.WebApplication.Grpc.Mappers;

/// <summary>
/// Маппинг gRPC PatientGrpc -> доменная сущность Patient
/// </summary>
public static class PatientGrpcMapper
{
    public static Patient ToDomain(this PatientGrpc grpc) => new()
    {
        Id = Guid.Parse(grpc.Id),
        PassportNumber = grpc.PassportNumber,
        Name = grpc.Name,
        Surname = grpc.Surname,
        Patronymic = grpc.Patronymic,
        BirthDate = DateOnly.Parse(grpc.BirthDate),
        Address = grpc.Address,
        Gender = grpc.Gender.ToDomain(),
        BloodType = grpc.BloodType.ToDomain(),
        RhesusFactor = grpc.RhesusFactor.ToDomain(),
        PhoneNumber = grpc.PhoneNumber
    };
}
