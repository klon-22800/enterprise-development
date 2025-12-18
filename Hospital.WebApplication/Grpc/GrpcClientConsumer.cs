using Grpc.Core;
using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Hospital.Grpc.Contracts;

namespace Hospital.WebApplication.Grpc;

public class GrpcClientConsumer
{
    private readonly IDoctorRepository _doctorRepo;
    private readonly IRepository<Patient> _patientRepo;
    private readonly IAppointmentRepository _appointmentRepo;
    private readonly GenerationService.GenerationServiceClient _grpcClient;

    public GrpcClientConsumer(
        IDoctorRepository doctorRepo,
        IRepository<Patient> patientRepo,
        IAppointmentRepository appointmentRepo,
        GenerationService.GenerationServiceClient grpcClient)
    {
        _doctorRepo = doctorRepo;
        _patientRepo = patientRepo;
        _appointmentRepo = appointmentRepo;
        _grpcClient = grpcClient;
    }

    public async Task StartGenerationAsync(int totalCount, int batchSize, CancellationToken cancellationToken = default)
    {
        using var call = _grpcClient.Generate();

        // Отправляем команду StartGeneration
        await call.RequestStream.WriteAsync(new GenerationRequest
        {
            Start = new StartGeneration
            {
                TotalCount = totalCount,
                BatchSize = batchSize
            }
        });

        // Обработка ответного потока
        await foreach (var response in call.ResponseStream.ReadAllAsync(cancellationToken))
        {
            if (response.PayloadCase == GenerationResponse.PayloadOneofCase.Batch)
            {
                var batch = response.Batch;

                // Сохраняем Doctors
                foreach (var doc in batch.Doctors)
                {
                    var doctor = new Doctor
                    {
                        Id = Guid.Parse(doc.Id),
                        PassportNumber = doc.PassportNumber,
                        Name = doc.Name,
                        Surname = doc.Surname,
                        Patronymic = doc.Patronymic,
                        BirthDate = DateOnly.Parse(doc.BirthDate),
                        SpecializationId = Guid.Parse(doc.SpecializationId),
                        Experience = doc.Experience
                    };
                    await _doctorRepo.CreateAsync(doctor);
                }

                // Сохраняем Patients
                foreach (var pat in batch.Patients)
                {
                    var patient = new Patient
                    {
                        Id = Guid.Parse(pat.Id),
                        PassportNumber = pat.PassportNumber,
                        Name = pat.Name,
                        Surname = pat.Surname,
                        Patronymic = pat.Patronymic,
                        BirthDate = DateOnly.Parse(pat.BirthDate),
                        Address = pat.Address,
                        Gender = (Hospital.Core.Domain.Shared.Enums.Gender)pat.Gender,
                        BloodType = pat.BloodType.ToDomain(),
                        RhesusFactor = pat.RhesusFactor.ToDomain(),
                        PhoneNumber = pat.PhoneNumber
                    };
                    await _patientRepo.CreateAsync(patient);
                }

                // Сохраняем Appointments
                foreach (var app in batch.Appointments)
                {
                    var appointment = new Appointment
                    {
                        Id = Guid.Parse(app.Id),
                        AppointmentTime = DateTime.Parse(app.AppointmentTime),
                        OfficeNumber = app.OfficeNumber,
                        IsRepeated = app.IsRepeated,
                        DoctorId = Guid.Parse(app.DoctorId),
                        PatientId = Guid.Parse(app.PatientId)
                    };
                    await _appointmentRepo.CreateAsync(appointment);
                }

                // Отправляем ack
                await call.RequestStream.WriteAsync(new GenerationRequest
                {
                    Ack = new BatchAck { BatchNumber = batch.BatchNumber }
                });
            }
            else if (response.PayloadCase == GenerationResponse.PayloadOneofCase.Completed)
            {
                Console.WriteLine($"Generation completed. Total batches: {response.Completed.TotalBatches}");
                break;
            }
            else if (response.PayloadCase == GenerationResponse.PayloadOneofCase.Error)
            {
                Console.WriteLine($"Generation error: {response.Error.Message}");
                break;
            }
        }

        await call.RequestStream.CompleteAsync();
    }
}
