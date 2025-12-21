using Hospital.Core.Domain.Models;
using Hospital.Grpc.Contracts;

namespace Hospital.WebApplication.Grpc.Mappers;

/// <summary>
/// Маппинг gRPC AppointmentGrpc -> доменная сущность Appointment
/// </summary>
public static class AppointmentGrpcMapper
{
    public static Appointment ToDomain(this AppointmentGrpc grpc) => new()
    {
        Id = Guid.Parse(grpc.Id),
        AppointmentTime = DateTime.Parse(grpc.AppointmentTime),
        OfficeNumber = grpc.OfficeNumber,
        IsRepeated = grpc.IsRepeated,
        DoctorId = Guid.Parse(grpc.DoctorId),
        PatientId = Guid.Parse(grpc.PatientId)
    };
}
