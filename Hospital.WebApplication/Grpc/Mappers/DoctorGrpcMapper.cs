using Hospital.Core.Domain.Models;
using Hospital.Grpc.Contracts;

namespace Hospital.WebApplication.Grpc.Mappers;

/// <summary>
/// Маппинг gRPC DoctorGrpc ->  доменная сущность Doctor
/// </summary>
public static class DoctorGrpcMapper
{
    public static Doctor ToDomain(this DoctorGrpc grpc) => new()
    {
        Id = Guid.Parse(grpc.Id),
        PassportNumber = grpc.PassportNumber,
        Name = grpc.Name,
        Surname = grpc.Surname,
        Patronymic = grpc.Patronymic,
        BirthDate = DateOnly.Parse(grpc.BirthDate),
        SpecializationId = Guid.Parse(grpc.SpecializationId),
        Experience = grpc.Experience
    };
}
